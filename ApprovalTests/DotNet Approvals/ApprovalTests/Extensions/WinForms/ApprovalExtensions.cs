using System.Windows.Forms;

namespace ApprovalTests.Extensions.WinForms
{
	public static class ApprovalExtensions
	{
		public static void ShouldBeApproved(this Control c)
		{
			ApprovalTests.WinForms.Approvals.Approve(c);
		}
	}
}