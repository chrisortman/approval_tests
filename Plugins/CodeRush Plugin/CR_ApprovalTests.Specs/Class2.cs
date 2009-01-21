using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ApprovalTests.WinForms;
using NUnit.Framework;

namespace CR_ApprovalTests.Specs
{
	[TestFixture]
	public class TestOptions
	{
		[Test]
		public void RerunTestAfterApprovalCheck()
		{
			Form f = new Form();

			Options o = new Options();
			ApprovalToolsSettings s = new ApprovalToolsSettings { RunTestAfterApproval = true };
			o.UpdateScreen(s);
			f.Controls.Add(o);
			f.Show();
			Approvals.Approve(o);
		}
	}
}
