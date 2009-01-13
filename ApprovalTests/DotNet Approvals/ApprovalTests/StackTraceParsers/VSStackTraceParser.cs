using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace ApprovalTests.StackTraceParsers
{
	public class VSStackTraceParser : IStackTraceParser
	{
		private StackTrace stackTrace;

		public bool Parse(StackTrace trace)
		{
			stackTrace = trace;
			if (stackTrace.ToString().Contains("UnitTestExecuter"))
				return true;
			return false;
		}

		public string ApprovalName
		{
			get { return String.Format(@"{0}.{1}", TypeName, Method.Name); }
		}

		public string SourcePath
		{
			get { return Path.GetDirectoryName(FindApprovalFrame().GetFileName()); }
		}


		public MethodBase Method
		{
			get { return FindApprovalFrame().GetMethod(); }
		}

		private StackFrame FindApprovalFrame()
		{
			StackFrame[] frames = stackTrace.GetFrames();
			if (frames == null)
				return null;

			for (int i = 0; i < frames.Length; i++)
			{
				if (frames[i].GetMethod().Name == "_InvokeMethodFast")
					return frames[i - 1];
			}

			return null;
		}

		public string TypeName
		{
			get { return Method.DeclaringType.Name; }
		}
	}
}