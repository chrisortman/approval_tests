using ApprovalUtilities.Utilities;

namespace ApprovalTests.Reporters
{
	public class TortoiseDiffReporter : GenericDiffReporter
	{
		private static string PATH = DotNet4Utilities.GetPathInProgramFilesX86(@"TortoiseSVN\bin\tortoisemerge.exe");

		public TortoiseDiffReporter()
			: base(
				PATH,
				"Could not find TortoiseMerge at {0}, please install it (it's part of TortoiseSVN) http://tortoisesvn.net/ ".
					FormatWith(PATH))
		{
		}
	}
}