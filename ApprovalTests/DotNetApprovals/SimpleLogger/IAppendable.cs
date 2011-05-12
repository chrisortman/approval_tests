using System;

namespace SimpleLogger
{
	public interface IAppendable
	{
		void AppendLine(String text);
	}
}