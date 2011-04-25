using ApprovalTests.Core;

namespace ApprovalTests
{
	public interface IReporterWithApprovalPower : IApprovalFailureReporter
	{
		bool ApprovedWhenReported();
		
	}
}