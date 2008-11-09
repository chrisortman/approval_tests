using System;
using System.IO;
using System.Linq;
using ApprovalTests.Writers;

namespace ApprovalTests.Approvers
{
	public class FileApprover : IApprovalApprover
	{
		private readonly IApprovalWriter writer;
		private readonly IApprovalNamer namer;
		private string approved;
		private string received;
		private ApprovalException failure;

		public FileApprover(IApprovalWriter writer, IApprovalNamer namer)
		{
			this.writer = writer;
			this.namer = namer;
		}

		public bool Approve()
		{
			string basename = string.Format(@"{0}\{1}", namer.SourcePath, namer.Name);
			approved = writer.GetApprovalFilename(basename);
			received = writer.GetReceivedFilename(basename);
			received = writer.WriteReceivedFile(received);

			if (!File.Exists(approved))
			{
				failure = new ApprovalMissingException(received, approved);
				return false;
			}

			if (!File.ReadAllBytes(received).SequenceEqual(File.ReadAllBytes(approved)))
			{
				failure = new ApprovalMismatchException(received, approved);
				return false;
			}

			return true;
		}

		public void Fail()
		{
			throw failure;
		}

		public void ReportFailure(IApprovalFailureReporter reporter)
		{
			 reporter.Report(approved, received);
		}

		public void CleanUpAfterSucess()
		{
			File.Delete(received);
		}
	}
}