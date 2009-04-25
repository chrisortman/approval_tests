using System;
using System.Collections.Generic;
using ApiReporter.Tests.Examples;
using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;
using System.Reflection;
namespace ApiReporter.Tests
{
	[TestFixture]
	public class ApiReporterTest
	{
		private const string ExampleNamespace = "ApiReporter.Tests.Examples";
		[Test]
		public void FindClassesTest()
		{
			Type[] c = new ApiNamespaceReporter(typeof(A)).FindClassesForNamespace(ExampleNamespace);
			Approvals.Approve(c, "classes");
		}

		[Test]
		[UseReporter(Reporter =typeof(OpenReceivedFileReporter))]
		public void ReporterOutputTest()
		{
			ApiNamespaceReporter apiReporter = new ApiNamespaceReporter(typeof(A));
			string output = apiReporter.GenerateReport(ExampleNamespace);
			Approvals.Approve(output);
		}

		[Test]
		[UseReporter(Reporter = typeof(OpenReceivedFileReporter))]
		public void ReporterOutputAPITest()
		{
			ApiNamespaceReporter apiReporter = new ApiNamespaceReporter(typeof(Approvals));
			string output = apiReporter.GenerateReport("ApprovalTests");
			Approvals.Approve(output);
		}

		[Test]
		public void ClassFormatingTest()
		{
			Assert.AreEqual("Foo", ApiNamespaceReporter.FormatClassName(typeof(IFoo)));
			Assert.AreEqual("List", ApiNamespaceReporter.FormatClassName(typeof(List<string>)));
		}
	}

	public interface IFoo
	{
		
	}
}