using System;
using ApprovalUtilities.Persistence;

namespace ApprovalUtilities.SimpleLogger
{
	public class Logger
	{
		private static LoggerInstance log = new LoggerInstance();

		public static IAppendable Writer
		{
			get { return log.Writer; }
			set { log.Writer = value; }
		}

		public static StringBuilderLogger LogToStringBuilder()
		{
			return log.LogToStringBuilder();
		}

		public static void MarkerIn()
		{
			log.MarkerIn();
		}

		public static void MarkerOut()
		{
			log.MarkerOut();
		}

		public static String Event(string message, params object[] items)
		{
			return log.Event(message, items);
		}

		public static String Message(string message)
		{
			return log.Message(message);
		}

		public static void Variable(string name, object value)
		{
			log.Variable(name, value);
		}

		public static string Sql(string sql)
		{
			return log.Sql(sql);
		}

		public static void Warning(Exception exception, params string[] additional)
		{
			log.Warning(exception, additional);
		}

		public static void Warning(string format, params object[] data)
		{
			log.Warning(format, data);
		}

		public static void Show(bool markerIn = true, bool variables = true, bool events = true, bool sql = true,
								bool timestamp = true, bool timeDifference = true)
		{
			log.Show(markerIn, variables, events, sql, timestamp, timeDifference);
		}

		public static void UseTimer(ILoader<DateTime> timeLoader)
		{
			log.UseTimer(timeLoader);
		}
	}
}