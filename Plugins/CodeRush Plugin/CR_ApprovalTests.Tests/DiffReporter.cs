using System;
using System.Diagnostics;
using System.IO;
using ApprovalTests.Core;

namespace CR_ApprovalTests.Tests
{
	internal class DiffReporter : IApprovalFailureReporter
	{
		#region IApprovalFailureReporter Members

		public void Report(string approved, string received)
		{
			if (!File.Exists(approved))
				File.Create(approved);
			Process.Start("tortoisemerge.exe", String.Format("/base:\"{0}\" /mine:\"{1}\"", received, approved));
		}

		public bool ApprovedWhenReported()
		{
			return false;
		}

		#endregion
	}
}