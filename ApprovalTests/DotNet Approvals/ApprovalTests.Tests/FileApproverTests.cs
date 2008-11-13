using System;
using ApprovalTests.Approvers;
using ApprovalTests.Writers;
using Moq;
using NUnit.Framework;

namespace ApprovalTests.Tests
{
	[TestFixture]
	public class FileApproverTests
	{
		[Test]
		public void TestFailureDueToMissingApproval()
		{
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
			var writer = new Mock<IApprovalWriter>();
			var namer = new Mock<IApprovalNamer>();
			var basePath = Environment.CurrentDirectory + @"\..\..\";
			namer.Expect(n => n.Name).Returns("a");
			namer.Expect(n => n.SourcePath).Returns(basePath);
			writer.Expect(w => w.WriteReceivedFile(It.IsAny<string>())).Returns(basePath + receivedFile);
			writer.Expect(w => w.GetApprovalFilename(It.IsAny<string>())).Returns(basePath + approvedFile);
			writer.Expect(w => w.GetReceivedFilename(It.IsAny<string>())).Returns(basePath + receivedFile);
			
            FileApprover approver = new FileApprover(writer.Object, namer.Object);

			Assert.AreEqual(expected, approver.Approve());
		}
	}
}