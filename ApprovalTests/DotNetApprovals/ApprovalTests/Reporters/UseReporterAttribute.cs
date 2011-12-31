using System;
using System.Linq;
using ApprovalTests.Core;

namespace ApprovalTests.Reporters
{
	[AttributeUsage(AttributeTargets.All)]
	public class UseReporterAttribute : Attribute
	{
		public UseReporterAttribute(Type reporter)
		{
			Reporter = (IApprovalFailureReporter) Activator.CreateInstance(reporter);
		}

		public UseReporterAttribute(params Type[] reporters)
		{
			Reporter = new MultiReporter(reporters.Select(r => (IApprovalFailureReporter)Activator.CreateInstance(r)));
		}

		public IApprovalFailureReporter Reporter { get; set; }
	}
}