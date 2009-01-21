using System.Windows.Forms;
using ApprovalTests.StackTraceParsers;

namespace ApprovalTests.WinForms
{
	public class Approvals
	{
		public static void Approve(Control control)
		{
			EnsureControlDisplaysCorrectlyByAddingItToAHiddenForm(control);

			ApprovalTests.Approvals.Approve(new ApprovalControlWriter(control), new StackTraceNamer(), ApprovalTests.Approvals.GetDefaultReporter());
		}

		private static void EnsureControlDisplaysCorrectlyByAddingItToAHiddenForm(Control control)
		{
			// This is a hack
			var f = new Form
			{
				Height = 0,
				Width = 0,
				ShowInTaskbar = false
			};

			f.Controls.Add(control);
			f.Show();
		}
	}
}