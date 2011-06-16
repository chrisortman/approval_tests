using System;
using System.Diagnostics;
using System.IO;

namespace ApprovalUtilities.SimpleLogger
{
    public class FileWriter : IAppendable
    {
        public FileWriter()
        {
            LogFile = Path.GetTempPath() + "Logger.txt";
        }

        public void AppendLine(string text)
        {
            File.AppendAllText(LogFile, text + Environment.NewLine);
        }

        private string logFile;

        public string LogFile
        {
            get { return logFile; }
            set
            {
                logFile = value;
                var message = "Logging to:" + logFile;
                Console.WriteLine(message);
                Debug.WriteLine(message);
            }
        }
    }
}