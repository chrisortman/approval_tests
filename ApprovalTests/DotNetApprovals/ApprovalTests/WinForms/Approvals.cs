using System;
using System.Windows.Forms;
using ApprovalTests.Namers;

namespace ApprovalTests.WinForms
{
	[Obsolete("Use WinFormsApprovals instead")]
	public class Approvals
	{
		public static void Approve(Form form)
		{
			ApprovalTests.Approvals.Approve(new ApprovalFormWriter(form));
		}

		public static void Approve(Control control)
		{
			ApprovalTests.Approvals.Approve(new ApprovalControlWriter(control));
		}
	}
	public class WinFormsApprovals
	{
		public static void Verify(Form form)
		{
			ApprovalTests.Approvals.Approve(new ApprovalFormWriter(form));
		}

		public static void Verify(Control control)
		{
			ApprovalTests.Approvals.Approve(new ApprovalControlWriter(control));
		}
	}
}