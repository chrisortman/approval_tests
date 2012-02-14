using System;
using System.Collections.Generic;
using ApprovalTests.Core;
using System.Linq;

namespace ApprovalTests.Reporters
{
	public class FirstWorkingReporter:IEnvironmentAwareReporter
	{
		private readonly IEnumerable<IEnvironmentAwareReporter> reporters;
		public FirstWorkingReporter(params IEnvironmentAwareReporter[] reporters):
			this((IEnumerable<IEnvironmentAwareReporter>)reporters)
		{
			
		}

		public FirstWorkingReporter(IEnumerable<IEnvironmentAwareReporter> reporters)
		{
			this.reporters = reporters;
		}
		public void Report(string approved, string received)
		{
			reporters.First(x=> x.IsWorkingInThisEnvironment()).Report(approved, received);
		}
		public bool IsWorkingInThisEnvironment()
		{
			return reporters.Any(x => x.IsWorkingInThisEnvironment());
		}
	}
}