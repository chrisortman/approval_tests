using System;
using ApprovalUtilities.Utilities;

namespace ApprovalTests.Reporters
{
	public class BeyondCompareReporter : GenericDiffReporter
	{
		readonly static string PATH = DotNet4Utilities.GetPathInProgramFilesX86(@"Beyond Compare 3\BCompare.exe");
		public readonly static BeyondCompareReporter INSTANCE = new BeyondCompareReporter();

		public BeyondCompareReporter()
			: base(PATH, "Could not find BeyondCompare at {0}, please install it".FormatWith(PATH))
		{

		}
	}
	public class DotNet4Utilities
	{
		public static string GetPathInProgramFilesX86(string path)
		{
			return Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + @"\" + path;
		}
	}

}