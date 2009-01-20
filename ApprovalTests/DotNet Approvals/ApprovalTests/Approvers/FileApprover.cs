using System.Collections;
using System.Collections.Generic;
using System.IO;
using ApprovalTests.Exceptions;
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
			approved = Path.GetFullPath(writer.GetApprovalFilename(basename));
			received = Path.GetFullPath(writer.GetReceivedFilename(basename));
			received = writer.WriteReceivedFile(received);

			if (!File.Exists(approved))
			{
				failure = new ApprovalMissingException(received, approved);
				return false;
			}

			if (!Compare(File.ReadAllBytes(received), File.ReadAllBytes(approved)))
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

		private static bool Compare(ICollection<byte> bytes1, ICollection<byte> bytes2)
		{
			if (bytes1.Count != bytes2.Count)
				return false;

			var e1 = bytes1.GetEnumerator();
			var e2 = bytes2.GetEnumerator();
			
			while (e1.MoveNext() && e2.MoveNext())
			{
				if (e1.Current != e2.Current)
					return false;
			}
            
			return true;
		}
	}
}