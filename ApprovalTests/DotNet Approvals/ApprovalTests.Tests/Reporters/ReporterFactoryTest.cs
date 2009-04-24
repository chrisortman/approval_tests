using System;
using NUnit.Framework;

namespace ApprovalTests.Tests.Reporters
{
    [TestFixture]
    [UseReporter(reporter=typeof(MyReporter2))]
    public class ReporterFactoryTest
    {
        [Test]
        [UseReporter(reporter = typeof(MyReporter))]
        public void TestMethodOverride()
        {

            Assert.AreEqual(typeof(MyReporter), Approvals.GetDefaultReporter().GetType());
            

        }
        [Test]
        public void TestClassLevel()
        {

            Assert.AreEqual(typeof(MyReporter2), Approvals.GetDefaultReporter().GetType());
         

        }
    }


    public class MyReporter : IApprovalFailureReporter
    {
        

        public void Report(string approved, string received)
        {
            
        }

        public bool ApprovedWhenReported()
        {
            return false;
        }
    }
    public class MyReporter2 : IApprovalFailureReporter
    {
        

        public void Report(string approved, string received)
        {
            
        }

        public bool ApprovedWhenReported()
        {
            return false;
        }
    }
}