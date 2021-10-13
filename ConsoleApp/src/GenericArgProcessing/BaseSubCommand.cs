using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;

namespace ConsoleApp.GenericArgProcessing {
	
	/// <summary>
	/// A subcommand that can have some number of options and default arguments.
	/// </summary>
	/// <typeparam name="TSetup">The type of setup object that will be passed to the options when parsing arguments.</typeparam>
	/// <typeparam name="TInfo">The type of object that will be passed to the options when executing options.</typeparam>
	public abstract class BaseSubCommand<TSetup, TInfo> where TInfo : IProcessObject {
		
		private readonly IImmutableList<BaseOption<TSetup, TInfo>> _options;
		private readonly IImmutableDictionary<string, BaseOption<TSetup, TInfo>> _optionLookup;


		// order matters here, this is the same order in which the options will get processed
		protected BaseSubCommand(IImmutableList<BaseOption<TSetup, TInfo>> options) {
			_options = options;
			HashSet<string> aliasSet = new HashSet<string>();
			foreach (var option in options) {
				if (option.Aliases.Count == 0)
					throw new ArgProcessProgrammerException($"Option '{option.GetType().Name}' has no aliases.");
				foreach (string al in option.Aliases)
					if (!aliasSet.Add(al))
						throw new ArgProcessProgrammerException($"Alias '{al}' is present twice in subcommand '{GetType().Name}'.");
			}
			_optionLookup = options
				.SelectMany(o => o.Aliases, (option, alias) => (option, alias))
				.ToImmutableDictionary(tuple => tuple.alias, tuple => tuple.option);
		}


		public bool TryGetOption(string alias, out BaseOption<TSetup, TInfo> option)
			=> _optionLookup.TryGetValue(alias, out option);


		public int TotalEnabledOptions => _options.Count(o => o.Enabled);


		/// <summary>
		/// Process an argument that was determined to not be passed to an option, should throw if this argument is invalid.
		/// </summary>
		/// <exception cref="ArgProcessUserException">Thrown when the given argument isn't valid.</exception>
		protected abstract void ParseDefaultArgument(string arg);
		

		/// <summary>
		/// Parses the arguments, passing in the setup object to each option as it's parsed.
		/// </summary>
		protected void ParseArgs(string[] args, TSetup setupObj, int argIdx) {
			Debug.Assert(argIdx >= 0 && argIdx <= args.Length - 1);
			Reset();
			while (argIdx < args.Length) {
				string arg = args[argIdx];
				if (_optionLookup.TryGetValue(arg, out BaseOption<TSetup, TInfo> option)) {
					switch (option.Arity) {
						case Arity.Zero:
							option.Enable(setupObj, null);
							break;
						case Arity.ZeroOrOne:
							// check if the next arg looks like an option first
							if (argIdx + 1 < args.Length && _optionLookup.ContainsKey(args[argIdx + 1]))
								option.Enable(setupObj, null);
							else 
								goto case Arity.One;
							break;
						case Arity.One:
							if (argIdx + 1 < args.Length && option.CanUseAsArg(args[argIdx + 1])) {
								// we can use this as an arg to the option, advance so we skip it on the next iteration
								option.Enable(setupObj, args[++argIdx]);
							} else {
								if (option.Arity == Arity.One)
									throw new ArgProcessProgrammerException($"Could not create argument for option '{option.Aliases[0]}'");
								option.Enable(setupObj, null);
							}
							break;
						default:
							throw new ArgumentOutOfRangeException(nameof(option.Arity), $"invalid arity \"{option.Arity}\"");
					}
				} else {
					ParseDefaultArgument(arg);
				}
				argIdx++;
			}
			foreach (var option in _options.Where(o => o.Enabled))
				option.AfterParse(setupObj);
		}


		/// <summary>
		/// Executes all options, Dispose will be called on infoObj after completion.
		/// </summary>
		/// <param name="infoObj">The object passed to all options during processing and post-processing</param>
		protected void Process(TInfo infoObj) {
			var enabledOptions = _options.Where(o => o.Enabled).ToImmutableList();
			while (infoObj.CanAdvance()) {
				infoObj.Advance();
				foreach (var option in enabledOptions)
					option.Process(infoObj);
			}
			infoObj.DoneProcessing();
			foreach (var option in enabledOptions)
				option.PostProcess(infoObj);
		}


		/// <summary>
		/// Resets the state of this subcommand and all options before parsing new arguments.
		/// </summary>
		protected virtual void Reset() {
			foreach (var option in _options)
				option.Reset();
		}
	}

	/// <summary>
	/// A class that will be passed to options during processing. Note: A call will be made to advance before this is
	/// passed to options.
	/// </summary>
	public interface IProcessObject {
		// returns true if we can go to the "next thing" to be processed (e.g. a demo)
		public bool CanAdvance();
		// do all the setup required to get the "next thing" ready
		public void Advance();
		// resource cleanup if necessary (called after process but before post process)
		public void DoneProcessing();
	}
}
