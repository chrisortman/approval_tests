using System;
using System.Windows.Forms;

namespace ApprovalTests.WinForms
{
	[Obsolete("Use WinFormsApprovals instead")]
	public class Approvals
	{
		public static void Approve(Form form)
		{
			WinFormsApprovals.Verify(form);
		}

		public static void Approve(Control control)
		{
			WinFormsApprovals.Verify(control);
		}
	}
}