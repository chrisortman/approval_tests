using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using ApprovalTests.Core;

namespace ApprovalTests
{
	public class ApprovalControlWriter : IApprovalWriter
	{
		private readonly Control control;

		public ApprovalControlWriter(Control controlHandle)
		{
			control = controlHandle;
		}

		#region IApprovalWriter Members

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

		#endregion

		private void EnsureControlDisplaysCorrectly()
		{
			AddToHiddenForm();
		}

		private void AddToHiddenForm()
		{
			var tempForm = new Form
			               	{
			               		ShowInTaskbar = false,
			               		AllowTransparency = true,
			               		Opacity = 0
			               	};

			tempForm.Controls.Add(control);
			tempForm.Show();
			control.Show();
		}
	}
}