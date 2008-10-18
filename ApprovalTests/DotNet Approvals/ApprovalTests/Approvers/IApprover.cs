namespace ApprovalTests.Approvers
{
	public interface IApprovalApprover
	{
		bool Approve();
		void Fail();
		void ReportFailure(IApprovalFailureReporter reporter);
		void CleanUpAfterSucess();
	}
}