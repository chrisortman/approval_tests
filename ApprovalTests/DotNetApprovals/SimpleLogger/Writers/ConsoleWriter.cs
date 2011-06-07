using System;
using SimpleLogger;

namespace SplitEntireFile.Test
{
    public class ConsoleWriter : IAppendable
    {
        public void AppendLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}