using System;
using ApprovalTests.Core;
using NUnit.Framework;

namespace ApprovalTests.Tests.Reporters
{
    [TestFixture]
    [UseReporter(Reporter=typeof(MyReporter2))]
    public class ReporterFactoryTest
    {
        [Test]
        [UseReporter(Reporter = typeof(MyReporter))]
        public void TestMethodOverride()
        {

            Assert.AreEqual(typeof(MyReporter), Approvals.GetReporter().GetType());
            

        }
        [Test]
        public void TestClassLevel()
        {

            Assert.AreEqual(typeof(MyReporter2), Approvals.GetReporter().GetType());
         

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