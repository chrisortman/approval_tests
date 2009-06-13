using ApprovalTests.Core.Exceptions;
using MbUnit.Framework;

namespace ApprovalTests.Tests
{
	[TestFixture]
	public class ApprovalsTest
	{
		[Test]
		[Parallelizable]
		public void TextMatchesApproval()
		{
			Approvals.Approve("should be a approved");
		}

		[Test]
		[Parallelizable]
		public void EnumerableMatchesApproval()
		{
			Approvals.Approve(new[]
			{
				"abc", "123", "!@#"
			}, "collection");
		}

		[Test]
		[Parallelizable]
		[UseReporter(typeof(CleanupReporter))]
		[ExpectedException(typeof (ApprovalMismatchException))]
		public void TextDoesNotMatchApproval()
		{
			Approvals.Approve("should fail with mismatch");
		}

		[Test]
		[Parallelizable]
		[UseReporter(typeof(CleanupReporter))]
		[ExpectedException(typeof (ApprovalMissingException))]
		public void TextNotApprovedYet()
		{
			Approvals.Approve("should fail with a missing exception");
		}

		[Test]
		[Parallelizable]
		[UseReporter(typeof(CleanupReporter))]
		[ExpectedException(typeof (ApprovalMismatchException))]
		public void EnumerableDoesNotMatchApproval()
		{
			Approvals.Approve(new[]
			{
				"Does not match"
			}, "collection");
		}

		[Test]
		[Parallelizable]
		[UseReporter(typeof(CleanupReporter))]
		[ExpectedException(typeof (ApprovalMissingException))]
		public void EnumerableNotApprovedYet()
		{
			Approvals.Approve(new[]
			{
				"Not approved"
			}, "collection");
		}
	}
}