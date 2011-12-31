using System;
using System.Collections.Generic;
using ApprovalTests.Core;

namespace ApprovalTests.Reporters
{
	public class MultiReporter : IApprovalFailureReporter
	{
		private readonly IEnumerable<IApprovalFailureReporter> reporters;

		public MultiReporter(params IApprovalFailureReporter[] reporters)
		{
			this.reporters = reporters;
		}
		public MultiReporter(IEnumerable<IApprovalFailureReporter> reporters)
		{
			this.reporters = reporters;
		}

		public void Report(string approved, string received)
		{
			foreach (var reporter in reporters)
			{
				reporter.Report(approved,received);
			}
		}
	}
}