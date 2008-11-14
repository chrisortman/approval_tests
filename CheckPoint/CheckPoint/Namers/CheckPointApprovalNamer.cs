using System;
using ApprovalTests.Approvers;

namespace CheckPoint.Namers
{
	public class CheckPointApprovalNamer : IApprovalNamer
	{
		private readonly CheckPointWatch checkPoint;
		private readonly string test;
		private readonly string name;

		public CheckPointApprovalNamer(object id, object testID, CheckPointWatch checkPointWatch)
		{
			test = testID.ToString();
			name = id.ToString();
			checkPoint = checkPointWatch;
		}

		public string SourcePath
		{
			get { return String.Format(@"..\..\CheckPoints\{0}", test); }
		}

		public string Name
		{
			get { return String.Format("{0}.{1}", name, checkPoint.CallCount); }
		}
	}
}