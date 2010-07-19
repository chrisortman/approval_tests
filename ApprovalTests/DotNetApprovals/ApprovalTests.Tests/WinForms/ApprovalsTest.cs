using System.Drawing;
using System.Windows.Forms;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace ApprovalTests.Tests.WinForms
{
	[TestFixture]
    [UseReporter(typeof(DiffReporter))]
	public class ApprovalsTest
	{
		[Test]
		public void TestControlApproved()
		{
			ApprovalTests.WinForms.Approvals.Approve(new Button {BackColor = Color.Blue});
		}

		[Test]
		public void TestFormApproval()
		{
			ApprovalTests.WinForms.Approvals.Approve(new Form());
		}
	}
}