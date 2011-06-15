using System;
using ApprovalUtilities.Persistence;

namespace ApprovalUtilities.SimpleLogger
{
	internal class Clock : ILoader<DateTime>
	{
		public DateTime Load()
		{
			return DateTime.Now;
		}
	}
}