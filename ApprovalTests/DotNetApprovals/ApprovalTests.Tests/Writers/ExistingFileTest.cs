using System;
using ApprovalTests.Reporters;
using ApprovalTests.Writers;
using NUnit.Framework;

namespace ApprovalTests.Tests.Writers
{
    [TestFixture]
    [UseReporter(typeof (DiffReporter))]
    public class ExistingFileTest
    {
     
        [Test]
        public void TestExistFileIsApproved()
        {
					var basePath = Environment.CurrentDirectory + @"\..\..\";

            Approvals.Approve(new ExistingFileWriter(basePath + "a.png"), Approvals.GetDefaultNamer(), Approvals.GetReporter());
        }

    }
}