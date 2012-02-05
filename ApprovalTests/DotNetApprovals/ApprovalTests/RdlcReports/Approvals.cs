using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Reporting.WinForms;

namespace ApprovalTests.RdlcReports
{
	[Obsolete("Use RdlcApprovals instead")]
	public class Approvals
	{
		public static void ApproveReport(string reportname, object data)
		{
			RdlcApprovals.VerifyReport(reportname, data);
		}

		public static void ApproveReport(string reportname, string datasourceName, object data)
		{
			RdlcApprovals.VerifyReport(reportname, datasourceName, data);
		}

		public static void ApproveReport(string reportname, Assembly assembly, string datasourceName, object data)
		{
			RdlcApprovals.VerifyReport(reportname, assembly, datasourceName, data);
		}

		public static void ApproveReport<T>(string reportname, Assembly assembly, params Tuple<string, T>[] dataInfo)
		{
			RdlcApprovals.VerifyReport(reportname, assembly, dataInfo);
		}

		public static void ApproveRdlcReport(string reportname, Assembly assembly,
																				 Action<ReportDataSourceCollection, IList<string>> populateDataSources)
		{
			RdlcApprovals.VerifyRdlcReport(reportname, assembly, populateDataSources);
		}

		public static byte[] RenderReport(LocalReport localReport, string format)
		{
			return RdlcApprovals.RenderReport(localReport, format);
		}
	}
}