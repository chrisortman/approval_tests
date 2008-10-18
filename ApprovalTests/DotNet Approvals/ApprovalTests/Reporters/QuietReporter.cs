using System.Diagnostics;

namespace ApprovalTests
{
	public class QuietReporter : IApprovalFailureReporter
	{
		public static QuietReporter Instance = new QuietReporter();


		public void Report(string approved, string received)
		{
			Debug.WriteLine(string.Format("move /Y \"{0}\" \"{1}\"", received, approved));
		}

		public bool ApprovedWhenReported()
		{
			return false;
		}
	}
}