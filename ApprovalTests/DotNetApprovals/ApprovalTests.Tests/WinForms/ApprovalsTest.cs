using System.Drawing;
using System.Windows.Forms;
using NUnit.Framework;

namespace ApprovalTests.Tests.WinForms
{
	[TestFixture]
	public class ApprovalsTest
	{
		[Test]
		public void TestControlApproved()
		{
			ApprovalTests.WinForms.Approvals.Approve(new Button {BackColor = Color.Blue});
		}

		[Test]
		[Ignore("Currently not working with build system")]
		public void TestFormApproval()
		{
			ApprovalTests.WinForms.Approvals.Approve(new Form());
		}
	}
}