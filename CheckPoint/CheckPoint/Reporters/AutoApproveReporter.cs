using System.Diagnostics;
using System.IO;
using ApprovalTests;

namespace CheckPoint.Reporters
{
	public class AutoApproveReporter : IApprovalFailureReporter
	{
		private string approvedPath;
		private string receivedPath;

		public void Report(string approved, string received)
		{
			approvedPath = approved;
			receivedPath = received;
			
			Debug.WriteLine("Auto Approving");
			Debug.WriteLine("Received: " + received);
			Debug.WriteLine("");
			Debug.WriteLine(File.ReadAllText(received));

			Debug.WriteLine("");
		}

		public bool ApprovedWhenReported()
		{
			File.Copy(receivedPath, approvedPath, true);
			File.Delete(receivedPath);
			return false;
		}
	}
}