using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ApprovalTests.Extensions.WinForms;
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
		public void TestControlApprovedExtension()
		{
			var l = new Label
			{
				Text = "approve this"
			};

			l.ShouldBeApproved();
		}
	}
}
