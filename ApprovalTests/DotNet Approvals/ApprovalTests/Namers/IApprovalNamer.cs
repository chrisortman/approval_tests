namespace ApprovalTests.Approvers
{
	public interface IApprovalNamer
	{
		string SourcePath {get;}
		string Name { get; }
	}
}