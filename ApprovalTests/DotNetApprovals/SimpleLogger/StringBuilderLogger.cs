using System.Text;

namespace SimpleLogger
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
	}
}