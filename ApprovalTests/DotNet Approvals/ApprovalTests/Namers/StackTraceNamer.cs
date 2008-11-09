using System.Diagnostics;
using ApprovalTests.Approvers;

namespace ApprovalTests.StackTraceParsers
{
	public class StackTraceNamer : IApprovalNamer
	{
		private readonly StackTraceParser stackTraceParser;

		public StackTraceNamer()
		{
			stackTraceParser = new StackTraceParser();
			stackTraceParser.Parse(new StackTrace(true));
		}

		public string Name
		{
			get { return stackTraceParser.ApprovalName; }
		}

		public string SourcePath
		{
			get { return stackTraceParser.SourcePath; }
		}
	}
}