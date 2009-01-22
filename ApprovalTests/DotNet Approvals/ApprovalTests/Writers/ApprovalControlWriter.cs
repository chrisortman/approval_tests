using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
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
			EnsureControlDisplaysCorrectly();

			var b = new Bitmap(control.Width, control.Height, PixelFormat.Format32bppArgb);
			control.DrawToBitmap(b, new Rectangle(0, 0, control.Width, control.Height));
			b.Save(received, ImageFormat.Png);

			return received;
		}

		private void EnsureControlDisplaysCorrectly()
		{
			using (Graphics g = control.CreateGraphics())
			{
				g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				g.SmoothingMode = SmoothingMode.HighQuality;
				
				var points = new Point[2];
                points[0].X = 0;
                points[0].Y = 0;
				points[1].X = control.Width;
                points[1].Y = control.Height;
				g.DrawLines(Pens.Red,points );
			}


			AddToHiddenForm();
		}

		private void AddToHiddenForm()
		{
			var tempForm = new Form
			{
				ShowInTaskbar = false,
				WindowState = FormWindowState.Minimized
			};

			tempForm.Controls.Add(control);
			tempForm.Show();
		}
	}
}