using System;
using System.Diagnostics;

namespace ApprovalTests.StackTraceParsers
{
	public class StackTraceParser : IStackTraceParser
	{
		private IStackTraceParser parser;

		private static readonly IStackTraceParser[] parsers = {
		                                                      	new NUnitStackTraceParser(), new MSpecStackTraceParser(), new VSStackTraceParser()
		                                                      };


		public bool Parse(StackTrace stackTrace)
		{
			foreach (IStackTraceParser p in parsers)
			{
				if (p.Parse(stackTrace))
				{
					parser = p;
					return true;
				}
			}

			throw new Exception(string.Format("Could not determine name from {0}", stackTrace));
		}

		public string ApprovalName
		{
			get { return parser.ApprovalName; }
		}

		public string SourcePath
		{
			get { return parser.SourcePath; }
		}
	}
}