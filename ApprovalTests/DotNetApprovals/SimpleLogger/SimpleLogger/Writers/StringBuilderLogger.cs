using System.Text;
using ApprovalUtilites;

namespace ApprovalUtilities.SimpleLogger.Writers
{
    public class StringBuilderLogger : IAppendable
    {
        private StringBuilder sb = new StringBuilder();

        public void AppendLine(string text)
        {
            sb.Append(text + "\r\n");
        }

        public override string ToString()
        {
            return sb.ToString();
        }

        public string ScrubPath(string path)
        {
            return ToString().Replace(path, @"...\");
        }
    }

   
}