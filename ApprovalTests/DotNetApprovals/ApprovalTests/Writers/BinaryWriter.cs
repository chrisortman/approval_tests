using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ApprovalTests.Core;

namespace ApprovalTests.Writers
{
	public class BinaryWriter : IApprovalWriter
	{
		public BinaryWriter(byte[] data)
		{
			Data = data;
		}

		public BinaryWriter(byte[] data, string extensionWithoutDot)
		{
			Data = data;
			ExtensionWithDot = EnsureDoc(extensionWithoutDot);
		}

		private string EnsureDoc(string extension)
		{
			string extensionWithDot = String.Format(".{0}", extension);
			return extension.StartsWith(".") ? extension : extensionWithDot;
		}
        public byte[] Data { get; set; }
		public string ExtensionWithDot { get; set; }

		#region IApprovalWriter Members

		public string GetApprovalFilename(string basename)
		{
			return String.Format("{0}.approved{1}", basename, ExtensionWithDot);
		}

		public string GetReceivedFilename(string basename)
		{
			return String.Format("{0}.received{1}", basename, ExtensionWithDot);
		}

		public string WriteReceivedFile(string received)
		{
			Directory.CreateDirectory(Path.GetDirectoryName(received));
			File.WriteAllBytes(received, Data);
			return received;
		}

		#endregion

	}
}
