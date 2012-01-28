using System.Drawing;
using System.Windows.Forms;
using ApprovalTests.Namers;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace ApprovalTests.Tests.WinForms
{
	[TestFixture]
	//[UseReporter(typeof(DiffReporter), )]
	public class ApprovalsTest
	{
		[Test]
		public void TestControlApproved()
		{
			NamerFactory.AsMachineSpecificTest();
			ApprovalTests.WinForms.Approvals.Approve(new Button {BackColor = Color.LightBlue, Text = "Help"});
		}

		[Test]
		public void TestFormApproval()
		{
			NamerFactory.AsMachineSpecificTest();
			ApprovalTests.WinForms.Approvals.Approve(new Form());
		}
	}
}