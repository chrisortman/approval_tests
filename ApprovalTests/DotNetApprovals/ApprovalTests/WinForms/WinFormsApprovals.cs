using System.Windows.Forms;

namespace ApprovalTests.WinForms
{
	public class WinFormsApprovals
	{
		public static void Verify(Form form)
		{
			ApprovalTests.Approvals.Verify(new ApprovalFormWriter(form));
		}

		public static void Verify(Control control)
		{
			ApprovalTests.Approvals.Verify(new ApprovalControlWriter(control));
		}
	}
}