using ApprovalTests.Core;
using ApprovalTests.Writers;

namespace ApprovalTests.Core
{
	public class Approvals
	{
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
	}
}