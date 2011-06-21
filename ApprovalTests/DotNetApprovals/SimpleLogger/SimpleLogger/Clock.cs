using System;
using ApprovalUtilities.Persistence;

namespace ApprovalUtilities.SimpleLogger
{
	public class Clock : ILoader<DateTime>
	{
		public DateTime Load()
		{
			return DateTime.Now;
		}
	}
}