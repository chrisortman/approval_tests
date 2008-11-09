using System.Diagnostics;

namespace ApprovalTests.StackTraceParsers
{
	public interface IStackTraceParser
	{
		bool Parse(StackTrace stackTrace);
		string ApprovalName { get; }
		string SourcePath { get; }
	}
}