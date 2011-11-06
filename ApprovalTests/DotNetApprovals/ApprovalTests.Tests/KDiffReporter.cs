using System.Diagnostics;
using ApprovalTests.Core;
using ApprovalUtilities.Utilities;

namespace ApprovalTests.Tests
{
	public class KDiffReporter : IApprovalFailureReporter
	{
		public void Report(string approved, string received)
		{
			FileUtilities.EnsureFileExists(approved);
			Process.Start(@"C:\Program Files\KDiff3\kdiff3.exe",approved + " " + received);
		}
	}
}
