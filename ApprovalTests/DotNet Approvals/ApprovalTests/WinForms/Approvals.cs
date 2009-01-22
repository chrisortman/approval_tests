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
			var tempForm = new Form
			{
				Height = 0,
				Width = 0,
				ShowInTaskbar = false,
				IsMdiContainer = true,
			};

			if (control is Form)
				AddToMdiContainerAndShow((Form) control, tempForm);
			else
				tempForm.Controls.Add(control);

			tempForm.Show();
			control.Show();
		}

		private static void AddToMdiContainerAndShow(Form form, Form mdiContainer)
		{
			form.MdiParent = mdiContainer;
		}
	}
}