using System.Diagnostics;

namespace ApprovalTests.Reporters
{
	public class OpenReceivedFileReporter : IApprovalFailureReporter
	{
		public void Report(string approved, string received)
		{
			Process.Start(received);
		}

		public bool ApprovedWhenReported()
		{
			return false;
		}
	}
}