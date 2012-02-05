using System;
using System.Data;
using System.Reflection;
using ApprovalTests.Namers;
using ApprovalTests.Persistence.DataSets;
using ApprovalTests.RdlcReports;
using NUnit.Framework;
using ReportingDemo;

namespace ApprovalTests.Tests.Persistence.Datasets
{
	//[UseReporter(typeof(ClipboardReporter))]
	[TestFixture]
	public class DatasetTest
	{
		private const string ReportName = "ReportingDemo.InsultsReport.rdlc";

		private static DataTable GetDefaultData()
		{
			return new InsultsDataSet.InsultsDataTable().AddTestDataRows(1);
		}
		private static Assembly GetAssembly()
		{
			return typeof(InsultsDataSet).Assembly;
		}

		[Test]
		public void TestSimpleReportWith1Dataset()
		{
			RdlcApprovals.VerifyReport(ReportName, GetDefaultData());
		}

		[Test]
		public void TestSimpleReportWithDatasetInAssembly()
		{
			RdlcApprovals.VerifyReport(ReportName, "Model", GetDefaultData());
		}

		[Test]
		public void TestReport()
		{
			RdlcApprovals.VerifyReport(ReportName, GetAssembly(), Tuple.Create("Model", GetDefaultData()));
		}


		[Test]
		public void TestSimpleReportExplict()
		{
			RdlcApprovals.VerifyReport(ReportName, GetAssembly(), "Model", GetDefaultData());
		}

		[Test]
		public void TestDataSourceNames()
		{
			NamerFactory.Clear();
			var message = "";
			try
			{
				RdlcApprovals.VerifyReport(ReportName, GetAssembly(), "purposelyMisspelt", GetDefaultData());
			}
			catch (Exception e)
			{
				message = e.Message;
			}
			Approvals.Verify(message);
		}

		[SetUp]
		public void NamerSetUp()
		{
			NamerFactory.AsMachineSpecificTest();
		}
	}
}