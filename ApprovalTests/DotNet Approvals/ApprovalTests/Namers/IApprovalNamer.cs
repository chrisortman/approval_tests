namespace ApprovalTests.Approvers
{
	public interface IApprovalNamer
	{
		string GetSourceFilePath();
		string GetApprovalName();
	}
}