using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using ApprovalTests.Approvers;
using ApprovalTests.StackTraceParsers;
using ApprovalTests.Writers;

namespace ApprovalTests
{
	public class Approvals
	{
		public static void Approve(string data)
		{
			Approve(new ApprovalTextWriter(data), new NunitStackTraceNamer(), FindDefaultReporter());
		}

		public static void Approve(IApprovalWriter writer, IApprovalNamer namer, IApprovalReporter reporter)
		{
			Approve(new FileApprover(writer, namer), reporter);
		}

		public static void Approve(IApprovalApprover approver, IApprovalReporter reporter)
		{
			bool approved = approver.Approve();
			if (!approved)
				approved = approver.Report(reporter);
			if (!approved)
				approver.Fail();
			else
				approver.CleanUpReceived();
		}

		public static void Approve(string label, IEnumerable enumerable)
		{
			Approve(EnumerableWriter.write(label, enumerable));
		}

		public static void Approve(Control form)
		{
			Approve(new ApprovalControlWriter(form), new NunitStackTraceNamer(), FindDefaultReporter());
		}

		private static readonly List<IApprovalReporter> reporters = new List<IApprovalReporter>();

		public static IApprovalReporter FindDefaultReporter()
		{
			if (reporters.Count == 0)
				return QuietReporter.Instance;
			return reporters[0];
		}

		public static void RegisterReporter(IApprovalReporter reporter)
		{
			reporters.Insert(0, reporter);
		}

		public static void UnregisterReporter(IApprovalReporter reporter)
		{
			reporters.Remove(reporter);
		}

		public static void UnregisterLastReporter()
		{
			reporters.RemoveAt(0);
		}
	}
}