using System;
using System.Diagnostics;
using System.IO;
using ApprovalUtilites;

namespace SimpleLogger.Writers
{
    public class FileWriter : IAppendable
    {
        public FileWriter()
        {
            LogFile = Path.GetTempPath() + "Logger.txt";
        }

        public void AppendLine(string text)
        {
            lock (this)
            {
                File.AppendAllText(LogFile, text + Environment.NewLine);
            }
        }

        private string logFile;

        public string LogFile
        {
            get { return logFile; }
            set
            {
                logFile = value;
                EnsureDirectoryExists(new FileInfo(logFile).Directory);
                var message = "Logging to:" + logFile;
                Console.WriteLine(message);
                Debug.WriteLine(message);
            }
        }

        public static void EnsureDirectoryExists(DirectoryInfo directory)
        {
            directory.Refresh();
            if (directory.Exists)
            {
                return;
            }

            EnsureDirectoryExists(directory.Parent);

            directory.Create();
        }
    }
}