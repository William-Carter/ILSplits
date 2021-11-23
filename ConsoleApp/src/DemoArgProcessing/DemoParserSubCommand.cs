using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using ConsoleApp.DemoArgProcessing.Options;
using ConsoleApp.GenericArgProcessing;

namespace ConsoleApp.DemoArgProcessing {
	
	public class DemoParserSubCommand : BaseSubCommand<DemoParsingSetupInfo, DemoParsingInfo> {

		private readonly List<FileSystemInfo> _argPaths;
		public ICollection<FileSystemInfo> ArgPaths => _argPaths;
		private readonly SortedSet<FileInfo> _demoPaths;
		public ICollection<FileInfo> DemoPaths => _demoPaths;
		public override string VersionString => "version TODO";
		public override string UsageString => $"{Utils.GetExeName()} <demos/dirs> [options]";


		public DemoParserSubCommand(IImmutableList<BaseOption<DemoParsingSetupInfo, DemoParsingInfo>> options)
			: base(options)
		{
			_argPaths = new List<FileSystemInfo>();
			_demoPaths = new SortedSet<FileInfo>(new AlphanumComparatorFileInfo());
		}
		
		
		// assume this is a demo file or a folder of files
		protected override void ParseDefaultArgument(string arg) {
			if (File.Exists(arg)) {
				FileInfo fi = new FileInfo(arg);
				if (fi.Extension == ".dem")
					_argPaths.Add(new FileInfo(arg));
				else
					throw new ArgProcessUserException($"File \"{arg}\" is not a valid demo file.");
			} else if (Directory.Exists(arg)) {
				_argPaths.Add(new DirectoryInfo(arg));
			} else {
				throw new ArgProcessUserException($"\"{arg}\" is not a valid file or directory!");
			}
		}


		protected override void Reset() {
			base.Reset();
			_argPaths.Clear();
			_demoPaths.Clear();
		}


		public override void Execute(params string[] args) {
			if (CheckHelpAndVersion(args))
				return;
			DemoParsingSetupInfo setupInfo = new DemoParsingSetupInfo();
			ParseArgs(args, setupInfo);
			// check if we have/need a folder output
			if (setupInfo.FolderOutputRequired && setupInfo.FolderOutput == null)
				throw new ArgProcessUserException($"folder output is required, use \"{OptOutputFolder.DefaultAliases[0]}\" to set one.");
			// enable listdemo implicitly if there are no other options
			if (TotalEnabledOptions == 0) {
				if (TryGetOption(OptListdemo.DefaultAliases[0], out var option)) {
					option.Enable(null);
					option.AfterParse(setupInfo);
				} else {
					throw new ArgProcessProgrammerException("listdemo option not passed to demo sub-command.");
				}
			}
			if (setupInfo.ExecutableOptions == 0)
				throw new ArgProcessUserException("no executable options given!");
			// flatten directories/files into just files
			foreach (FileSystemInfo fileSystemInfo in _argPaths) {
				switch (fileSystemInfo) {
					case FileInfo fi:
						_demoPaths.Add(fi);
						break;
					case DirectoryInfo di:
						_demoPaths.UnionWith(Directory.GetFiles(di.FullName, "*.dem",
							setupInfo.ShouldSearchForDemosRecursively ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)
							.Select(s => new FileInfo(s)));
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
			if (_demoPaths.Count == 0)
				throw new ArgProcessUserException("no demos found!");
			// Shorten the paths of the demos if possible, the shared path between the first and last paths will give
			// the overall shared path of everything. If it's empty then we know the demos span multiple drives.
			string commonParent = Utils.SharedPathSubstring(_demoPaths.Min.FullName, _demoPaths.Max.FullName);
			IEnumerable<(FileInfo demoPath, string displayName)> paths =
				_demoPaths.Select(demoPath => (
					demoPath,
					commonParent == ""
						? demoPath.FullName
						: PathExt.GetRelativePath(commonParent, demoPath.FullName)
				));
			using DemoParsingInfo parsingInfo = new DemoParsingInfo(setupInfo, paths.ToImmutableList());
			Process(parsingInfo);
		}
	}
}
