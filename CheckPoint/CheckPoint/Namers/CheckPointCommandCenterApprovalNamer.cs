using System;
using ApprovalTests.Approvers;

namespace CheckPoint.Namers
{
	public class CheckPointCommandCenterApprovalNamer : IApprovalNamer
	{
		private readonly object id;

		public CheckPointCommandCenterApprovalNamer(object testID)
		{
			id = testID;
		}

		public string SourcePath
		{
			get { return String.Format(@"..\..\CheckPoints\{0}", id); }
		}

		public string Name
		{
			get { return String.Format("CheckPointReport"); }
		}
	}
}