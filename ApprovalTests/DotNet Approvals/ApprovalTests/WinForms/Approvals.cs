using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ApprovalTests.StackTraceParsers;

namespace ApprovalTests.WinForms
{
	public class Approvals
	{
		public static void Approve(Control control)
		{
			ApprovalTests.Approvals.Approve(new ApprovalControlWriter(control), new StackTraceNamer(), ApprovalTests.Approvals.GetDefaultReporter());
		}
	}
}
