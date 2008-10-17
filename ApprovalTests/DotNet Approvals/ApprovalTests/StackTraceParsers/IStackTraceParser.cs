using System.Diagnostics;

namespace ApprovalTests.StackTraceParsers
{
	public interface IStackTraceParser
	{
		string ParseLabel(StackTrace stackTrace);
	}
}