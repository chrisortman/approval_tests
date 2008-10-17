using System;
using System.Diagnostics;
using System.Text;

namespace ApprovalTests.StackTraceParsers
{
	public class MSpecStackTraceParser : IStackTraceParser
	{
		private StackTrace stackTrace;

		public string ParseLabel(StackTrace trace)
		{
			stackTrace = trace;
			if (stackTrace.ToString().Contains("Machine.Specifications"))
				return String.Format("{0}{1}.{2}", BasePath, TypeName, DeclaringType.Name);
			return null;
		}

		public virtual Type DeclaringType
		{
			get { return FindApprovalMethodFrame().GetMethod().DeclaringType; }
		}

		public virtual string TypeName
		{
			get { return DeclaringType.FullName.Substring(0, DeclaringType.FullName.IndexOf(".")); }
		}

		private StackFrame FindApprovalMethodFrame()
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

		public string BasePath
		{
			get
			{
				if (DeclaringType.Assembly.Location == null)
					return null;

				string[] parts = DeclaringType.Assembly.Location.Split('\\');
				var s = new StringBuilder();
				for (int i = 0; i < parts.Length - 3; i++)
					s.Append(parts[i] + "\\");
				return s.ToString();
			}
		}
	}
}