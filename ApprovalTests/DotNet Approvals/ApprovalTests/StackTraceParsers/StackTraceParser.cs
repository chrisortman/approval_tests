using System;
using System.Diagnostics;

namespace ApprovalTests.StackTraceParsers
{
	public class StackTraceParser
	{
		private static readonly IStackTraceParser[] parsers = {
		                                                      	new NUnitStackTraceParser(), new MSpecStackTraceParser()
		                                                      };


		public static string GetLabel(StackTrace stackTrace)
		{
			foreach (IStackTraceParser p in parsers)
			{
				string parser = p.ParseLabel(stackTrace);

				if (parser != null)
					return parser;
			}

			throw new Exception(string.Format("Could not determin name from {0}", stackTrace));
		}
	}
}