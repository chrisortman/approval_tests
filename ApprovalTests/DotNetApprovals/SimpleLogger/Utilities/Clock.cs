using System;
using ApprovalUtilities.Persistence;

namespace ApprovalUtilities.Utilities
{
	public class Clock : ILoader<DateTime>
	{
		public virtual DateTime Load()
		{
			return DateTime.Now;
		}
	}

	public class MockClock : Clock
	{
		private int ticks;

		public override DateTime Load()
		{
			ticks += 10;
			return new DateTime(2011, 5, 6, 10, 30, 0, ticks);
		}
	}
}