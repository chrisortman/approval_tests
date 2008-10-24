using System.Windows.Forms;
using NUnit.Framework;

namespace ApprovalTests.Tests
{
	[TestFixture]
	public class ApprovalsTest
	{
		public void CleanUpAfter()
		{
			Approvals.RegisterReporter(new CleanupReporter());
		}

		[Test]
		public void TextMatchesApproval()
		{
			Approvals.Approve("should be approved");
		}


		[Test]
		public void EnumerableMatchesApproval()
		{
			Approvals.Approve(new[] {"abc", "123", "!@#"}, "collection");
		}

		[Test]
		public void TestControlApproved()
		{
			var l = new Label
			{
				Text = "approve this"
			};
			Approvals.Approve(l);
		}

		[Test]
		[ExpectedException(typeof (ApprovalMismatchException))]
		public void TextDoesNotMatchApproval()
		{
			CleanUpAfter();
			Approvals.Approve("should fail with mismatch");
		}

		[Test]
		[ExpectedException(typeof (ApprovalMissingException))]
		public void TextNotApprovedYet()
		{
			CleanUpAfter();
			Approvals.Approve("should fail with a missing exception");
		}

		[Test]
		[ExpectedException(typeof (ApprovalMismatchException))]
		public void EnumerableDoesNotMatchApproval()
		{
			CleanUpAfter();
			Approvals.Approve(new[] {"Does not match"}, "collection");
		}

		[Test]
		[ExpectedException(typeof (ApprovalMissingException))]
		public void EnumerableNotApprovedYet()
		{
			CleanUpAfter();
			Approvals.Approve(new[]{"Not approved"}, "collection");
		}
	}
}