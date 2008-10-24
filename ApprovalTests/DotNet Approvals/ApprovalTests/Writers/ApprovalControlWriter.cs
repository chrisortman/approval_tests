using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using ApprovalTests.Writers;

namespace ApprovalTests
{
	public class ApprovalControlWriter : IApprovalWriter
	{
		private readonly Control control;

		public ApprovalControlWriter(Control controlHandle)
		{
			control = controlHandle;
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
			Bitmap b = new Bitmap(control.Width, control.Height, PixelFormat.Format32bppArgb);
			control.DrawToBitmap(b, control.DisplayRectangle);
			b.Save(received, ImageFormat.Png);
			return received;
		}
	}
}