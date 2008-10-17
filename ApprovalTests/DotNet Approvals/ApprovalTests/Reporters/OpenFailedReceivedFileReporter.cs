using System.Diagnostics;

namespace ApprovalTests.Reporters
{
	public class OpenFailedReceivedFileReporter : IApprovalReporter
	{
		public bool Report(string approved, string received)
		{
			Process.Start(received);
			return false;
		}
	}
}