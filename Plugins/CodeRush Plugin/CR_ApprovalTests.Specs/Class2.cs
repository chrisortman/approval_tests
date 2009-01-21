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
			ApprovalToolsSettings s = new ApprovalToolsSettings
			{
				RunTestAfterApproval = true,
				UnitTestCommand = "TestDriven.Net",
				DiffImageTool =  @"C:\My Image Diff.exe",
				DiffTextTool =  @"C:\My Text Diff.exe",

			};
			o.UpdateScreen(s);
			f.Controls.Add(o);
			f.Show();
			Approvals.Approve(o);
		}
	}
}