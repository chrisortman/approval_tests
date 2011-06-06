using System.Diagnostics;
using ApprovalTests.Core;

namespace ApprovalTests.Reporters
{
	public class FileLauncherReporter : IApprovalFailureReporter
	{

		public void Report(string approved, string received)
		{
			new QuietReporter().Report(approved, received);
			Process.Start(received);
		}

	}
}