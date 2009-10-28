using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace ApprovalTests.StackTraceParsers
{
	public abstract class AttributeStackTraceParser : IStackTraceParser
	{
		private StackTrace stackTrace;

		public MethodBase Method
		{
			get { return FindApprovalFrame().GetMethod(); }
		}

		public string TypeName
		{
			get { return Method.DeclaringType.Name; }
		}

		#region IStackTraceParser Members

		public string ApprovalName
		{
			get { return String.Format(@"{0}.{1}", TypeName, Method.Name); }
		}

		public string SourcePath
		{
			get { return Path.GetDirectoryName(FindApprovalFrame().GetFileName()); }
		}

		public bool Parse(StackTrace trace)
		{
			stackTrace = trace;
			return FindApprovalFrame() != null;
		}

		#endregion

		public static StackFrame GetFirstFrameForAttribute(StackFrame[] frames, Type attribute)
		{
			if (frames == null)
				return null;


			for (int i = 0; i < frames.Length; i++)
			{
				if ( ContainsAttribute( frames[i].GetMethod().GetCustomAttributes( false ), attribute ) )
				{
					return frames[i];
				}
			}

			return null;
		}

		private static bool ContainsAttribute(object[] attributes, Type attribute)
		{
			foreach ( object a in attributes )
			{
				if ( a.GetType().FullName == attribute.FullName )
				{
					return true;
				}
			}

			return false;
		}

		private StackFrame FindApprovalFrame()
		{
			return GetFirstFrameForAttribute(stackTrace.GetFrames(), GetAttributeType());
		}

		public bool IsApplicable()
		{
			return GetAttributeType() != null;
		}

		protected abstract Type GetAttributeType();
	}
}