using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ApprovalTests.Writers;

namespace ApprovalTests
{
	public class ApprovalFormWriter : IApprovalWriter
	{
		private readonly Form form;

		public ApprovalFormWriter(Form form)
		{
			this.form = form;
		}

		public string GetApprovalFilename(string basename)
		{
			return basename + ".approved.png";
		}

		public string GetReceivedFilename(string basename)
		{
			return basename + ".received.png";
		}

		public string WriteReceivedFile(string received)
		{
			form.Show();

			var b = new Bitmap(form.Width, form.Height, PixelFormat.Format32bppArgb);
			form.DrawToBitmap(b, new Rectangle(0, 0, form.Width, form.Height));
			b.Save(received, ImageFormat.Png);

			return received;
		}
	}
}