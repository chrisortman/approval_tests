using System.Diagnostics;
using ApprovalTests.Core;

namespace ApprovalTests.Reporters
{
	public class QuietReporter : IApprovalFailureReporter
	{

		public void Report(string approved, string received)
		{
			Debug.WriteLine(string.Format("move /Y \"{0}\" \"{1}\"", received, approved));
		}

	}
}