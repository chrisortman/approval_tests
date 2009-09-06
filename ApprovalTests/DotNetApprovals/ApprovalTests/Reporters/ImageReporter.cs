using System.Diagnostics;
using System.IO;
using ApprovalTests.Core;
using ApprovalTests.Reporters;

namespace AlgorithmGui.Test
{
	public class ImageReporter : IApprovalFailureReporter
	{
		public bool ApprovedWhenReported()
		{
			return false;
		}

		private const string DiffImageTool = "TortoiseIDiff.exe";
		private const string DiffImageToolArgs = "/left:\"{0}\" /right:\"{1}\"";

		public void Report(string approved, string received)
		{
			if (!File.Exists(approved))
				new OpenReceivedFileReporter().Report(approved, received);
			else
				Process.Start(DiffImageTool, string.Format(DiffImageToolArgs, approved, received));
		}
	}
}
