using System.Collections.Generic;
using ApprovalTests.Approvers;
using ApprovalTests.StackTraceParsers;
using ApprovalTests.Writers;

namespace ApprovalTests
{
	public class Approvals
	{
		private static readonly List<IApprovalFailureReporter> reporters = new List<IApprovalFailureReporter>();

		public static void Approve(string data)
		{
			Approve(new ApprovalTextWriter(data), new StackTraceNamer(), GetDefaultReporter());
		}

		public static void Approve(IApprovalWriter writer, IApprovalNamer namer, IApprovalFailureReporter reporter)
		{
			Approve(new FileApprover(writer, namer), reporter);
		}

		public static void Approve(IApprovalApprover approver, IApprovalFailureReporter reporter)
		{
			if (approver.Approve())
				approver.CleanUpAfterSucess();
			else
			{
				approver.ReportFailure(reporter);

				if (reporter.ApprovedWhenReported())
					approver.CleanUpAfterSucess();
				else
					approver.Fail();
			}
		}

		public static void Approve<T>(IEnumerable<T> enumerable, string label)
		{
			Approve(EnumerableWriter.Write(enumerable, label));
		}

		public static void Approve<T>(IEnumerable<T> enumerable, string label, EnumerableWriter.CustomFormatter<T> formatter)
		{
			Approve(EnumerableWriter.Write(enumerable, label, formatter));
		}

		public static void Approve<T>(IEnumerable<T> enumerable, EnumerableWriter.CustomFormatter<T> formatter)
		{
			Approve(EnumerableWriter.Write(enumerable, formatter));
		}

        public static IApprovalFailureReporter GetDefaultReporter()
		{
			return reporters.Count == 0 ? QuietReporter.Instance : reporters[0];
		}

		public static void RegisterReporter(IApprovalFailureReporter reporter)
		{
			reporters.Insert(0, reporter); ;
		}

		public static void UnregisterReporter(IApprovalFailureReporter reporter)
		{
			reporters.Remove(reporter);
		}

		public static void UnregisterLastReporter()
		{
			reporters.RemoveAt(0);
		}
	}
}