using System;
using ApprovalTests.Core;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace ApprovalTests.Tests.Reporters
{
	[TestFixture]
	[UseReporter(typeof (ClassLevelReporter))]
	public class ReporterFactoryTest
	{
		[Test]
		public void TestClassLevel()
		{
			Assert.AreEqual(typeof (ClassLevelReporter), Approvals.GetReporter().GetType());
		}

		[Test]
		[UseReporter(typeof (MethodLevelReporter))]
		public void TestMethodOverride()
		{
			Assert.AreEqual(typeof (MethodLevelReporter), Approvals.GetReporter().GetType());
		}
		[Test]
		[UseReporter(typeof(MethodLevelReporter),typeof(ClassLevelReporter))]
		public void TestMultipleReporters()
		{
			Assert.AreEqual(typeof(MultiReporter), Approvals.GetReporter().GetType());
		}
		[Test]
		[UseReporter(typeof(MethodLevelReporter))]
		public void TestMethodOverrideWithSubMethod()
		{
			SubMethod();
		}

		private void SubMethod()
		{
			Assert.AreEqual(typeof(MethodLevelReporter), Approvals.GetReporter().GetType());
		}
	}


	public class MethodLevelReporter : IApprovalFailureReporter
	{

		public void Report(string approved, string received)
		{
		}


	}

	public class ClassLevelReporter : IApprovalFailureReporter
	{

		public void Report(string approved, string received)
		{
		}

	

	}
}