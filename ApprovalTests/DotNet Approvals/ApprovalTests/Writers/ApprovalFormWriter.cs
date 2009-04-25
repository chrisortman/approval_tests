using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using ApprovalTests.Core;

namespace ApprovalTests
{
	public class ApprovalFormWriter : IApprovalWriter
	{
		private readonly Form form;

		public ApprovalFormWriter(Form form)
		{
			this.form = form;
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
			EnsureControlDisplaysCorrectlyByAddingItToAHiddenForm();

			var b = new Bitmap(form.Width, form.Height, PixelFormat.Format32bppArgb);
			form.DrawToBitmap(b, new Rectangle(0, 0, form.Width, form.Height));
			b.Save(received, ImageFormat.Png);

			return received;
		}

		#endregion

		private void EnsureControlDisplaysCorrectlyByAddingItToAHiddenForm()
		{
			var tempForm = new Form
			               	{
			               		IsMdiContainer = true,
			               		ShowInTaskbar = false,
			               		AllowTransparency = true,
			               		Opacity = 0
			               	};

			form.MdiParent = tempForm;
			tempForm.Show();
			form.Show();
		}
	}
}