using System;
using System.Collections.Immutable;
using ConsoleApp.DemoArgProcessing;
using ConsoleApp.DemoArgProcessing.Options;
using ConsoleApp.DemoArgProcessing.Options.Hidden;
using ConsoleApp.GenericArgProcessing;

namespace ConsoleApp {

	public static class Program {

		public static void Main(string[] args) {
			// It would be nice if the console color was reset if ctrl+c is used, but I haven't gotten that to work yet.
			// This line of code just eats ctrl+c and delays it by way too much.
			// Console.CancelKeyPress += (sender,eventArgs) => Console.ResetColor();

			Console.WriteLine("UntitledParser by UncraftedName");
			// write everything with color since we have no idea what/when could have triggered any exceptions
			try {
				// only use the one sub command - no other commands for the demo parser
				DemoParserSubCommand demoParserCommand = new DemoParserSubCommand(
					new BaseOption<DemoParsingSetupInfo, DemoParsingInfo>[] {
						// order is the same order that the options will get processed in, shouldn't really matter
						new OptOutputFolder(),
						new OptRecursive(),
						new OptOverwrite(),
						new OptRegexSearch(),
						new OptPauses(),
						new OptJumps(),
						new OptCheatCommands(),
						new OptDataTablesDump(),
						new OptStringTablesDump(),
						new OptRemoveCaptions(),
						new OptChangeDemoDir(),
						new OptSmoothGlessHops(),
						new OptPositionDump(),
						new OptTeleports(),
						new OptPortals(),
						new OptInputs(),
						new OptDemoDump(),
						new OptTime() // this option should always be here and probably be last, it's sort of a default
					}.ToImmutableArray()
				);
				if (args.Length == 0) {
					Console.WriteLine(demoParserCommand.VersionString);
					Utils.WriteColor($"Usage: {demoParserCommand.UsageString}\n", ConsoleColor.DarkYellow);
					Utils.WriteColor(
						Utils.WillBeDestroyedOnExit()
							? $@"Open a new powershell window and use '.\{Utils.GetExeName()} --help' for help."
							: @$"Use '.\{Utils.GetExeName()} --help' for help.",
						ConsoleColor.Yellow);
				} else {
					demoParserCommand.Execute(Utils.FixPowerShellBullshit(args));
				}
			} catch (ArgProcessUserException e) {
				Utils.Warning($"User error: {e.Message}\n");
				Utils.WriteColor(@$"Use '.\{Utils.GetExeName()} --help' for help.", ConsoleColor.Yellow);
				Environment.ExitCode = 1;
			} catch (ArgProcessProgrammerException e) {
				Utils.Warning("Some programmer messed up, tell them they are silly (in a nice way).\n");
				Utils.Warning(e.ToString());
				Environment.ExitCode = 2;
			} catch (Exception e) {
				Utils.Warning("Unhandled exception! (This is not supposed to happen):\n");
				Utils.Warning(e.ToString());
				Environment.ExitCode = 3;
			}
			Console.ResetColor();
			if (Utils.WillBeDestroyedOnExit())
				Console.ReadKey();
		}
	}
}
