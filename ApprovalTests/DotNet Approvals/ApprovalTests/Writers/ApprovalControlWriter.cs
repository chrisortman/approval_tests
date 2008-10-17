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
			Bitmap b = new Bitmap(control.Width, control.Height);
			Rectangle rect = new Rectangle(0, 0, control.Width, control.Height);
			control.DrawToBitmap(b, rect);
			b.Save(received, ImageFormat.Png);
			return received;
		}
	}
}