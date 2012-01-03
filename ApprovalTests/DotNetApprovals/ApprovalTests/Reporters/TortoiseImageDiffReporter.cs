using ApprovalUtilities.Utilities;

namespace ApprovalTests.Reporters
{
	public class TortoiseImageDiffReporter : GenericDiffReporter
	{
		private static string PATH = DotNet4Utilities.GetPathInProgramFilesX86(@"TortoiseSVN\bin\TortoiseIDiff.exe");

		public TortoiseImageDiffReporter()
			: base(
				PATH, "/left:\"{0}\" /right:\"{1}\"",
				"Could not find TortoiseMerge at {0}, please install it (it's part of TortoiseSVN) http://tortoisesvn.net/ ".
					FormatWith(PATH))
		{
		}
	}
}