using System.Windows.Forms;
using ApprovalTests.StackTraceParsers;
using ApprovalTests.Writers;

namespace ApprovalTests.WinForms
{
	public class Approvals
	{
		public static void Approve(Form form)
		{
			ApprovalTests.Approvals.Approve(new ApprovalFormWriter(form), new StackTraceNamer(), ApprovalTests.Approvals.GetDefaultReporter());
		}

		public static void Approve(Control control)
		{
			ApprovalTests.Approvals.Approve(new ApprovalControlWriter(control), new StackTraceNamer(), ApprovalTests.Approvals.GetDefaultReporter());
		}
	}
}