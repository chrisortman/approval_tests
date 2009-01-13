using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ApprovalTests.Approvers;
using ApprovalTests.Extensions;
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
			Approve(EnumerableWriter.Write(label, enumerable));
		}

		public static IApprovalFailureReporter GetDefaultReporter()
		{
			return reporters.IsEmpty() ? QuietReporter.Instance : reporters.First();
		}

		public static void RegisterReporter(IApprovalFailureReporter reporter)
		{
			reporters.Push(reporter);
		}

		public static void UnregisterReporter(IApprovalFailureReporter reporter)
		{
			reporters.Remove(reporter);
		}

		public static void UnregisterLastReporter()
		{
			reporters.Pop();
		}

		public static void Approve<T>(IEnumerable<T> enumerable, System.Func<T, string> formatter, string label)
		{
			Approve(EnumerableWriter.Write(label,formatter, enumerable));
		}
		public static void Approve<T>(IEnumerable<T> enumerable, System.Func<T, string> formatter)
		{
			Approve(EnumerableWriter.Write(formatter, enumerable));
		}
	}
}