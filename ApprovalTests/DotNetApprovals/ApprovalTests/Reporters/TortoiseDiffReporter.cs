using ApprovalTests.Core;

namespace ApprovalTests.Reporters
{
	public class TortoiseDiffReporter : IEnvironmentAwareReporter
	{
		public static readonly TortoiseDiffReporter INSTANCE = new TortoiseDiffReporter();

		public bool IsWorkingInThisEnvironment()
		{
			return TortoiseTextDiffReporter.INSTANCE.IsWorkingInThisEnvironment() ||
						 TortoiseImageDiffReporter.INSTANCE.IsWorkingInThisEnvironment();
		}

		public void Report(string approved, string received)
		{
			if (TortoiseImageDiffReporter.IsImage(approved))
			{
				TortoiseImageDiffReporter.INSTANCE.Report(approved, received);
			}
			else
			{
				TortoiseTextDiffReporter.INSTANCE.Report(approved, received);
			}
		}
	}
}
