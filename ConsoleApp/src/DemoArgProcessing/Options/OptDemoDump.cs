using System;
using System.Collections.Immutable;
using System.IO;
using DemoParser.Utils;

namespace ConsoleApp.DemoArgProcessing.Options {
	
	public class OptDemoDump : DemoOption {
		
		public static readonly ImmutableArray<string> DefaultAliases = new[] {"--demo-dump", "-D"}.ToImmutableArray();
		
		
		public OptDemoDump() : base(
			DefaultAliases,
			$"Create a text representation of all parsable data in demos {OptOutputFolder.RequiresString}") {}
		
		
		public override void AfterParse(DemoParsingSetupInfo setupObj) {
			setupObj.ExecutableOptions++;
			setupObj.FolderOutputRequired = true;
		}


		public override void Process(DemoParsingInfo infoObj) {
			TextWriter tw = infoObj.StartWritingText("writing demo dump", "demo-dump");
			try {
				PrettyStreamWriter pw = new PrettyStreamWriter(((StreamWriter)tw).BaseStream);
				infoObj.CurrentDemo.PrettyWrite(pw);
				pw.Flush(); // see note at PrettyStreamWriter
			} catch (Exception) {
				Utils.Warning("Failed to create demo dump.");
			}
		}


		public override void PostProcess(DemoParsingInfo infoObj) {}
	}
}
