using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using ApprovalTests.Namers;
using ApprovalUtilities.CallStack;

namespace ApprovalTests.StackTraceParsers
{
	public abstract class AttributeStackTraceParser : IStackTraceParser
	{
		private Caller caller;


		public MethodBase Method
		{
			get { return FindApprovalFrame().Method; }
		}

		public string TypeName
		{
			get { return Method.DeclaringType.Name; }
		}

		public string AdditionalInfo
		{
			get
			{
				var additionalInformation = NamerFactory.AdditionalInformation;
				if (additionalInformation != null)
				{
					NamerFactory.AdditionalInformation = null;
					additionalInformation = "." + additionalInformation;
				}
				return additionalInformation;
			}
		}

		public string ApprovalName
		{
			get { return String.Format(@"{0}.{1}{2}", TypeName, Method.Name, AdditionalInfo); }
		}

		public string SourcePath
		{
			get { return Path.GetDirectoryName(FindApprovalFrame().StackFrame.GetFileName()); }
		}

		public abstract string ForTestingFramework { get; }

		public bool Parse(StackTrace trace)
		{
			caller = new Caller(trace, 0);
			return FindApprovalFrame() != null;
		}


		private static Caller GetFirstFrameForAttribute(Caller caller,string attributeName)
		{
			return caller.Callers.FirstOrDefault(c => ContainsAttribute(c.Method.GetCustomAttributes(false), attributeName));
		}

		private static bool ContainsAttribute(object[] attributes, string attributeName)
		{
			return attributes.Any(a => a.GetType().FullName.StartsWith(attributeName));
		}

		private Caller FindApprovalFrame()
		{
			return GetFirstFrameForAttribute(caller,GetAttributeType());
		}

		public bool IsApplicable()
		{
			return GetAttributeType() != null;
		}

		protected abstract string GetAttributeType();
	}
}