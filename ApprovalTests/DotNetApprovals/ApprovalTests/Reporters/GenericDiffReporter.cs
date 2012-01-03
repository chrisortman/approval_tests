using System;
using System.IO;
using ApprovalTests.Core;
using ApprovalUtilities.Utilities;

namespace ApprovalTests.Reporters
{
	public class GenericDiffReporter : IEnvironmentAwareReporter
	{
		protected string diffProgram;
		protected string arguments;
		protected string diffProgramNotFoundMessage;

		public GenericDiffReporter(string diffProgram, string diffProgramNotFoundMessage)
			: this(diffProgram, "\"{0}\" \"{1}\"", diffProgramNotFoundMessage)
		{
		}

		public GenericDiffReporter(string diffProgram, string argumentsFormat, string diffProgramNotFoundMessage)
		{
			this.diffProgram = diffProgram;
			this.arguments = argumentsFormat;
			this.diffProgramNotFoundMessage = diffProgramNotFoundMessage;
		}

		public void Report(string approved, string received)
		{
			if (!IsWorkingInThisEnvironment())
			{
				throw new Exception(diffProgramNotFoundMessage);
			}
			FileUtilities.EnsureFileExists(approved);
			DiffReporter.Launch(GetLaunchArguments(approved, received));
		}

		public LaunchArgs GetLaunchArguments(string approved, string received)
		{
			return new LaunchArgs(diffProgram,arguments.FormatWith(received,approved));
		}


		public bool IsWorkingInThisEnvironment()
		{
			return File.Exists(diffProgram);
		}
		

	}
}