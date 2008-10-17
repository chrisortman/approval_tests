using System.IO;
using ApprovalTests.Writers;

namespace ApprovalTests
{
	public class ApprovalTextWriter : IApprovalWriter
	{
		private readonly string data;

		public ApprovalTextWriter(string data)
		{
			this.data = data;
		}

		public string GetApprovalFilename(string basename)
		{
			return basename + ".approved.txt";
		}

		public string GetReceivedFilename(string basename)
		{
			return basename + ".received.txt";
		}

		public string WriteReceivedFile(string received)
		{
			File.WriteAllText(received, data);
			return received;
		}
	}
}