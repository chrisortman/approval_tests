using System.Windows.Forms;
using NUnit.Framework;

namespace ApprovalTests.Tests
{
	[TestFixture]
	public class ApprovalsTest
	{
		[SetUp]
		public void SetUp()
		{
			Approvals.RegisterReporter(new CleanupReporter());
		}

		[Test]
		public void TextMatchesApproval()
		{
			Approvals.Approve("should be approved");
		}

		[Test]
		[ExpectedException(typeof (ApprovalMismatchException))]
		public void TextDoesNotMatchApproval()
		{
			Approvals.Approve("should fail with mismatch");
		}

		[Test]
		[ExpectedException(typeof (ApprovalMissingException))]
		public void TextNotApprovedYet()
		{
			Approvals.Approve("should fail with a missing exception");
		}

		[Test]
		public void EnumerableMatchesApproval()
		{
			var a = new[]
			{
				"abc", "123", "!@#"
			};
			Approvals.Approve("a", a);
		}

		[Test]
		[ExpectedException(typeof (ApprovalMismatchException))]
		public void EnumerableDoesNotMatchApproval()
		{
			var a = new[]
			{
				"Does not match"
			};

			Approvals.Approve("a", a);
		}

		[Test]
		[ExpectedException(typeof (ApprovalMissingException))]
		public void EnumerableNotApprovedYet()
		{
			var a = new[]
			{
				"Not approved"
			};

			Approvals.Approve("a", a);
		}

		[Test]
		public void TestControlApproved()
		{
			Label l = new Label();
			l.Text = "approve this";
			Approvals.Approve(l);
		}
	}
}