using System.IO;
using System.Windows.Forms;
using ApprovalTests;

namespace CheckPoint.Reporters
{
	public class ManualApproveReporter : IApprovalFailureReporter
	{
		private string approvedPath;
		private string receivedPath;
		private bool isApproved;

		public void Report(string approved, string received)
		{
			approvedPath = approved;
			receivedPath = received;

			new DebugOutputReporter().Report(approved, received);

			isApproved = MessageBox.Show("Do you approve this?", "Approve", MessageBoxButtons.YesNo) == DialogResult.Yes;
		}

		public bool ApprovedWhenReported()
		{
			if (isApproved)
			{
				File.Copy(receivedPath, approvedPath, true);
				File.Delete(receivedPath);
			}
			return isApproved;
		}
	}
}