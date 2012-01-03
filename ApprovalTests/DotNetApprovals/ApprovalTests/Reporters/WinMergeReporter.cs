using ApprovalUtilities.Utilities;

namespace ApprovalTests.Reporters
{
	public class WinMergeReporter : GenericDiffReporter
	{
		private static string PATH = DotNet4Utilities.GetPathInProgramFilesX86(@"WinMerge\WinMergeU.exe");

		public WinMergeReporter()
			: base(PATH, "Could not find WinMerge at {0}, please install it".FormatWith(PATH))
		{
		}
	}
}