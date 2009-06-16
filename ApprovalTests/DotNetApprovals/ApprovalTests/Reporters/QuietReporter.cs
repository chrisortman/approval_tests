using System.Diagnostics;
using ApprovalTests.Core;

namespace ApprovalTests.Reporters
{
	public class QuietReporter : IApprovalFailureReporter
	{
		#region IApprovalFailureReporter Members

		public void Report(string approved, string received)
		{
			Debug.WriteLine(string.Format("move /Y \"{0}\" \"{1}\"", received, approved));
		}

		public bool ApprovedWhenReported()
		{
			return false;
		}

		#endregion
	}
}