using System.Diagnostics;
using System.IO;
using ApprovalTests;

namespace CheckPoint.Reporters
{
	public class DebugOutputReporter : IApprovalFailureReporter
	{
		public void Report(string approved, string received)
		{
			if (File.Exists(approved))
			{
				Debug.WriteLine("Failed Approval");
				Debug.WriteLine("Received: " + received);
				Debug.WriteLine("");
				Debug.WriteLine(File.ReadAllText(received));
				Debug.WriteLine("");
				Debug.WriteLine("Approved: " + approved);
				Debug.WriteLine("");
				Debug.WriteLine(File.ReadAllText(approved));
			}
			else
			{
				Debug.WriteLine("Failure - Item has not been approved yet");
				Debug.WriteLine("Received: " + received);
				Debug.WriteLine("");
				Debug.WriteLine(File.ReadAllText(received));
			}

			Debug.WriteLine("");
		}

		public bool ApprovedWhenReported()
		{
			return false;
		}
	}
}