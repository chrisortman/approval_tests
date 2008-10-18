namespace ApprovalTests
{
	public interface IApprovalFailureReporter
	{
		void Report(string approved, string received);
		bool ApprovedWhenReported();
	}
}