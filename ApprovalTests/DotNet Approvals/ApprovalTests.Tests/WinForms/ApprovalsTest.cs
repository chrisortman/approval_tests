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
			var l = new Label
			{
				Text = "approve this"
			};

			ApprovalTests.WinForms.Approvals.Approve(l);
		}

		[Test]
		public void TestFormApproval()
		{
			ApprovalTests.WinForms.Approvals.Approve(new Form());
		}
	}
}