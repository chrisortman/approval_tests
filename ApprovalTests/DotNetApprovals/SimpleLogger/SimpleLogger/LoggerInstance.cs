using System;
using System.Collections.Generic;
using System.Diagnostics;
using ApprovalUtilities.Persistence;
using ApprovalUtilities.SimpleLogger.Writers;
using ApprovalUtilities.Utilities;

namespace ApprovalUtilities.SimpleLogger
{
	public class LoggerInstance
	{
		public IAppendable Writer = new FileWriter();
		private int indent = 0;
		public int TabSize = 4;
		private bool showMarkerIn = true;
		private bool showVariables = true;
		private bool showEvents = true;
		private bool showSql = true;
		private bool showTimestamp = true;
		private bool showTimeDifference = true;
		private ILoader<DateTime> clock = new Clock();
		private DateTime lastTime = DateTime.Now;

		public StringBuilderLogger LogToStringBuilder()
		{
			Show(markerIn: true, variables: true, events: true, sql: true, timestamp: false, timeDifference: false);
			var log = new StringBuilderLogger();
			Writer = log;
			return log;
		}

		public void MarkerIn()
		{
			if (!showMarkerIn)
			{
				return;
			}
			var method = GetCallingMethod();
			Write("=> " + method);
			indent += TabSize;
		}

		public void MarkerOut()
		{
			if (!showMarkerIn)
			{
				return;
			}

			var method = GetCallingMethod();
			indent -= TabSize;
			Write("<= " + method);
		}

		private string GetCallingMethod()
		{
			var stackTrace = new StackTrace(true);
			StackFrame frame = null;
			for (var i = 2; i < stackTrace.FrameCount; i++)
			{
				frame = stackTrace.GetFrame(i);
				if (frame.GetMethod().DeclaringType.Namespace != this.GetType().Namespace)
				{
					break;
				}
			}
			return frame.GetMethod().DeclaringType.Name + "." + frame.GetMethod().Name + "()";
		}

		private void Write(string text)
		{
			var time = showTimestamp ? clock.Load() + " " : "";
			var difference = "";
			if (showTimeDifference)
			{
				var t = clock.Load();
				var diff = t - lastTime;
				lastTime = t;
				difference = string.Format("~{0:000000}ms ", diff.TotalMilliseconds);
			}

			var message = text.Replace(Environment.NewLine, Environment.NewLine + "\t");
			Writer.AppendLine(time + difference + GetIndentation() + message);
		}

		private string GetIndentation()
		{
			return "".PadLeft(indent, ' ');
			//				.Substring(0, indent);
		}

		public string Event(string message, params object[] items)
		{
			if (showEvents)
			{
				Write(string.Format("Event: " + message, items));
			}
			return message;
		}

		public string Message(string message)
		{
			if (showEvents)
			{
				Write("Message: " + message);
			}
			return message;
		}

		public void Variable(string name, object value)
		{
			if (showVariables)
			{
				Write("Variable: " + name + " = '" + value + "'");
			}
		}

		public string Sql(string sql)
		{
			if (showSql)
			{
				Write("Sql: " + sql);
			}
			return sql;
		}

		public string Miscellaneous(string label, string message)
		{
			Write("{0}: {1}".FormatWith(label, message));
			return message;
		}

		public void Warning(Exception except, params string[] additional)
		{
			PrintWarning(GetExceptionLines(except, additional));
		}

		public static string FormatExeption(Exception exception, params string[] additional)
		{
			return string.Join("\r\n", GetExceptionLines(exception, additional));
		}

		private static string[] GetExceptionLines(Exception except, params string[] additional)
		{
			var lines = new List<string>
			            	{
			            		string.Format("Exception: '{0}' | '{1}'", except.TargetSite, except.Source),
			            		except.Message,
			            		except.StackTrace
			            	};
			lines.AddRange(additional);
			return lines.ToArray();
		}

		public void Warning(string format, params object[] data)
		{
			PrintWarning(string.Format(format, data));
		}

		public void PrintWarning(params string[] lines)
		{
			const string lineBreakOut = "**************************************************************************************";
			const string lineBreakIn = "*                                                                                    *";
			Writer.AppendLine(lineBreakOut);
			Writer.AppendLine(lineBreakIn);
			foreach (var line in lines)
			{
				Writer.AppendLine("* " + line.Replace(Environment.NewLine, "{0}* ".FormatWith(Environment.NewLine)));
			}
			Writer.AppendLine(lineBreakIn);
			Writer.AppendLine(lineBreakOut);
		}


		public void Show(bool markerIn = true, bool variables = true, bool events = true, bool sql = true,
						 bool timestamp = true, bool timeDifference = true)
		{
			showMarkerIn = markerIn;
			showVariables = variables;
			showEvents = events;
			showSql = sql;
			showTimestamp = timestamp;
			showTimeDifference = timeDifference;
		}

		public void UseTimer(ILoader<DateTime> timeLoader)
		{
			lastTime = timeLoader.Load();
			clock = timeLoader;
		}
	}
}