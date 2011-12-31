using ApprovalTests.Core;
using ApprovalUtilities.Utilities;

namespace ApprovalTests.Tests.Reporters
{
	public class RecordingReporter : IApprovalFailureReporter
	{
		public void Report(string approved, string received)
		{
			this.CalledWith = "{0},{1}".FormatWith(approved, received);
		}

		public string CalledWith { get; set; }
	}
}