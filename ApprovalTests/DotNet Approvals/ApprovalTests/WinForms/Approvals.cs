using System.Windows.Forms;
using ApprovalTests.StackTraceParsers;

namespace ApprovalTests.WinForms
{
	public class Approvals
	{
		public static void Approve(Control control)
		{
			if (control is Form)
				control.Show();
			ApprovalTests.Approvals.Approve(new ApprovalControlWriter(control), new StackTraceNamer(), ApprovalTests.Approvals.GetDefaultReporter());
		}

		public static void Approve(Form form)
		{
			form.Show();
			ApprovalTests.Approvals.Approve(new ApprovalControlWriter(form), new StackTraceNamer(), ApprovalTests.Approvals.GetDefaultReporter());
		}
	}
}