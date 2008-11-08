using System.Diagnostics;

namespace ApprovalTests.StackTraceParsers
{
	public interface IStackTraceParser
	{
		string ParseApprovalName(StackTrace stackTrace);
	}
}