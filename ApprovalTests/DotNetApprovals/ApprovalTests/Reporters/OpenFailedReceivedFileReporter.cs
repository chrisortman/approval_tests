using System.Diagnostics;
using ApprovalTests.Core;

namespace ApprovalTests.Reporters
{
	public class OpenReceivedFileReporter : IApprovalFailureReporter
	{

		public void Report(string approved, string received)
		{
			new QuietReporter().Report(approved, received);
			Process.Start(received);
		}

	}
}