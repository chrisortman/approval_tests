using System;
using ApprovalTests.Approvers;
using NUnit.Framework;

namespace ApprovalTests.Tests
{
	public interface IApprovals
	{
		
	}

	[TestFixture]
	public class FileApproverTests
	{

		public IApprovals Approvals { get; set; }
		
		[Test]
		public void TestFailureDueToMissingApproval()
		{

			Approvals.
			AssertApprover("a.txt", "non_existing_file.txt", false);
		}

		[Test]
		public void TestFailureDueToMismatch()
		{
			AssertApprover("a.txt", "b.txt", false);
		}

		[Test]
		public void TestSuccess()
		{
			AssertApprover("a.txt", "a.txt", true);
		}

		private static void AssertApprover(string receivedFile, string approvedFile, bool expected)
		{
			var basePath = Environment.CurrentDirectory + @"\..\..\";
			var exception = FileApprover.Approve(basePath + approvedFile, basePath + receivedFile);
			Assert.AreEqual(expected, exception == null);
		}
	}
}