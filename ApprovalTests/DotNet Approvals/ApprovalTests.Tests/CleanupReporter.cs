using System.IO;

namespace ApprovalTests.Tests
{
	public class CleanupReporter : IApprovalReporter
	{
		public bool Report(string approved, string received)
		{
			File.Delete(received);
			return false;
		}
	}
}