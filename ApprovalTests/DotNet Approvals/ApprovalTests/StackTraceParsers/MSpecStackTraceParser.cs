using System;
using System.Diagnostics;
using System.IO;

namespace ApprovalTests.StackTraceParsers
{
	public class MSpecStackTraceParser : IStackTraceParser
	{
		private StackTrace stackTrace;

		public bool Parse(StackTrace trace)
		{
			stackTrace = trace;
			if (stackTrace.ToString().Contains("Machine.Specifications"))
				return true;
			return false;
		}

		public string ApprovalName
		{
			get { return String.Format("{0}.{1}", TypeName, DeclaringType.Name); }
		}

		public string SourcePath
		{
			get { return Path.GetDirectoryName(FindApprovalFrame().GetFileName()); }
		}

		public virtual Type DeclaringType
		{
			get { return FindApprovalFrame().GetMethod().DeclaringType; }
		}

		public virtual string TypeName
		{
			get { return DeclaringType.FullName.Substring(0, DeclaringType.FullName.IndexOf(".")); }
		}

		private StackFrame FindApprovalFrame()
		{
			StackFrame[] frames = stackTrace.GetFrames();
			if (frames == null)
				return null;

			for (int i = 0; i < frames.Length; i++)
			{
				if (frames[i].GetMethod().DeclaringType.FullName == "Machine.Specifications.Model.Specification")
					return frames[i - 1];
			}

			return null;
		}
	}
}