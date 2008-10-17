namespace ApprovalTests
{
	public interface IApprovalReporter
	{
		bool Report(string approved, string received);
	}
}