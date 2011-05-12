using System;

namespace SimpleLogger
{
	internal class Clock : ILoader<DateTime>
	{
		public DateTime Load()
		{
			return DateTime.Now;
		}
	}
}