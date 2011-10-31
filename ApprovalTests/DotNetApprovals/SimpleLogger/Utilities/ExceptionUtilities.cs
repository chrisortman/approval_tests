using System;
using System.Collections.Generic;
using System.Text;

namespace ApprovalUtilities.Utilities
{
	public static class ExceptionUtilities
	{
		public static string FormatExeption(Exception exception, params string[] additional)
		{
			return String.Join("\r\n", GetExceptionLines(exception, additional));
		}

		public static string[] GetExceptionLines(Exception except, params string[] additional)
		{
			var lines = new List<string>
			            	{
			            		String.Format("Exception: '{0}' | '{1}'", except.TargetSite, except.Source),
			            		except.Message,
			            		except.StackTrace
			            	};
			lines.AddRange(additional);
			return lines.ToArray();
		}

		public static string FormatAsError(params string[] lines)
		{
			var sb = new StringBuilder();
			const string lineBreakOut = "**************************************************************************************";
			const string lineBreakIn = "*                                                                                    *";
			sb.AppendLine(lineBreakOut);
			sb.AppendLine(lineBreakIn);
			foreach (var line in lines)
			{
				sb.AppendLine("* " + line.Replace(Environment.NewLine, "{0}* ".FormatWith(Environment.NewLine)));
			}
			sb.AppendLine(lineBreakIn);
			sb.AppendLine(lineBreakOut);
			return sb.ToString().Trim();
		}

		public static string FormatError(this Exception except, params string[] additional)
		{
			return FormatAsError(GetExceptionLines(except, additional));
		}
	}
}