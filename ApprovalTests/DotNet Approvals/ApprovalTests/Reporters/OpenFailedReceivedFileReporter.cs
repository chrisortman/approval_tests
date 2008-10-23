using System.Diagnostics;

namespace ApprovalTests.Reporters
{
	public class OpenReceivedFileReporter : IApprovalFailureReporter
	{
		public void Report(string approved, string received)
		{
			QuietReporter.Instance.Report(approved, received);
			Process.Start(received);
		}

		public bool ApprovedWhenReported()
		{
			return false;
		}
	}
}