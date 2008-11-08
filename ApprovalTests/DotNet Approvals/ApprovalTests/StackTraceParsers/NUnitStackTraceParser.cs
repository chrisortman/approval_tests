using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace ApprovalTests.StackTraceParsers
{
	public class NUnitStackTraceParser : IStackTraceParser
	{
		private StackTrace stackTrace;

		public string ParseApprovalName(StackTrace stackTrace)
		{
			this.stackTrace = stackTrace;
			if (this.stackTrace.ToString().Contains("NUnit") || this.stackTrace.ToString().Contains("TestDriven"))
				return String.Format(@"{0}\{1}.{2}", BasePath, TypeName, Method.Name);
			return null;
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

		public string BasePath
		{
			get
			{
				return Path.GetDirectoryName(FindApprovalFrame().GetFileName());
			}
		}
	}
}