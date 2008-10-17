namespace ApprovalTests.Approvers
{
	public interface IApprovalApprover
	{
		bool Approve();
		void Fail();
		bool Report(IApprovalReporter reporter);
		void CleanUpReceived();
	}
}