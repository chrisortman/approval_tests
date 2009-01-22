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
			EnsureControlDisplaysCorrectlyByAddingItToAHiddenForm();

			var b = new Bitmap(control.Width, control.Height, PixelFormat.Format32bppArgb);
			ControlPainter.PaintControl(Graphics.FromImage(b), control);
			b.Save(received, ImageFormat.Png);

			return received;
		}

		private void EnsureControlDisplaysCorrectlyByAddingItToAHiddenForm()
		{
			var tempForm = new Form
			{
				Height = 0,
				Width = 0,
				ShowInTaskbar = false
			};

			tempForm.Controls.Add(control);
			tempForm.Show();
		}
	}
}