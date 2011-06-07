using System;
using System.Diagnostics;
using SimpleLogger.Writers;

namespace SimpleLogger
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
            var time = showTimestamp ? clock.Load().ToString() + " " : "";
            var difference = "";
            if (showTimeDifference)
            {
                var t = clock.Load();
                var diff = t - lastTime;
                lastTime = t;
                difference = string.Format("~{0:000000}ms ", diff.TotalMilliseconds);
            }

            Writer.AppendLine(time + difference + GetIndentation() + text);
        }

        private string GetIndentation()
        {
            return "                                                                                           "
                .Substring(0, indent);
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

        public void Warning(Exception exception)
        {
            var LineBreak = "**************************************************************************************";
            Writer.AppendLine(LineBreak);
            Writer.AppendLine(exception.Message);
            Writer.AppendLine(exception.StackTrace);
            Writer.AppendLine(LineBreak);
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