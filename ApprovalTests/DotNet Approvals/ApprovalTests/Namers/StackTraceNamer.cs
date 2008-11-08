using System;
using System.Diagnostics;
using System.IO;
using ApprovalTests.Approvers;

namespace ApprovalTests.StackTraceParsers
{
	public class StackTraceNamer : IApprovalNamer
	{
		public string GetApprovalName()
		{
			return new StackTraceParser().ParseApprovalName(new StackTrace(true));
		}

		public string GetSourceFilePath()
		{
			var basePath = Environment.CurrentDirectory + @"\..\..\";
			// totally cheating!!!!
			return Path.GetFullPath(basePath);
		}
	}
}