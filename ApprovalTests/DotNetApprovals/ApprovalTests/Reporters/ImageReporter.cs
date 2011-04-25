using System.Diagnostics;
using System.IO;
using ApprovalTests.Core;

namespace ApprovalTests.Reporters
{
	public class ImageReporter : IApprovalFailureReporter
	{
	
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
