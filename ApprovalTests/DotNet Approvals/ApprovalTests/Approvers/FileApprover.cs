using System.IO;
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
			string basename = namer.GetSourceFilePath() + namer.GetApprovalName();
			approved = writer.GetApprovalFilename(basename);
			received = writer.GetReceivedFilename(basename);
			received = writer.WriteReceivedFile(received);

			if (!File.Exists(approved))
			{
				failure = new ApprovalMissingException(received, approved);
				return false;
			}

			if (File.ReadAllText(received) != File.ReadAllText(approved))
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

		public bool Report(IApprovalReporter reporter)
		{
			return reporter.Report(approved, received);
		}

		public void CleanUpReceived()
		{
			File.Delete(received);
		}
	}
}