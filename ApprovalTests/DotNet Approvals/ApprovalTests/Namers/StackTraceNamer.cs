using System;
using System.Diagnostics;
using System.IO;
using ApprovalTests.Approvers;

namespace ApprovalTests.StackTraceParsers
{
	public class NunitStackTraceNamer : IApprovalNamer
	{
		public string GetApprovalName()
		{
			return new NUnitStackTraceParser().ParseApprovalName(new StackTrace());
		}

		public string GetSourceFilePath()
		{
			var basePath = Environment.CurrentDirectory + @"\..\..\";
			// totally cheating!!!!
			return Path.GetFullPath(basePath);
		}
	}
}