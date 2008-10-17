using System;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace ApprovalTests.StackTraceParsers
{
	public class NUnitStackTraceParser : IStackTraceParser
	{
		private StackTrace stackTrace;

		public string ParseLabel(StackTrace stackTrace)
		{
			this.stackTrace = stackTrace;
			if (this.stackTrace.ToString().Contains("NUnit"))
				return String.Format("{0}{1}.{2}", BasePath, TypeName, Method.Name);
			return null;
		}

		public string ParseApprovalName(StackTrace stackTrace)
		{
			this.stackTrace = stackTrace;
			if (this.stackTrace.ToString().Contains("NUnit"))
				return String.Format("{0}.{1}", TypeName, Method.Name);
			return null;
		}

		public MethodBase Method
		{
			get { return FindApprovalMethodFrame().GetMethod(); }
		}

		private StackFrame FindApprovalMethodFrame()
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
			get { return Method.DeclaringType.FullName.Substring(0, Method.DeclaringType.FullName.IndexOf(".")); }
		}

		public string BasePath
		{
			get
			{
				var s = new StringBuilder();
				string[] parts = Method.DeclaringType.Assembly.Location.Split('\\');
				for (int i = 0; i < parts.Length - 3; i++)
					s.Append(parts[i] + "\\");
				return s.ToString();
				;
			}
		}
	}
}