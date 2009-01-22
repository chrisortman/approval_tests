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
			EnsureControlDisplaysCorrectlyByAddingItToAHiddenForm();

			var b = new Bitmap(form.Width, form.Height, PixelFormat.Format32bppArgb);
			ControlPainter.PaintControl(Graphics.FromImage(b), form);
			b.Save(received, ImageFormat.Png);

			return received;
		}

		private void EnsureControlDisplaysCorrectlyByAddingItToAHiddenForm()
		{
			var tempForm = new Form
			{
				Height = 0,
				Width = 0,
				ShowInTaskbar = false,
				IsMdiContainer = true
			};

			form.MdiParent = tempForm;
			tempForm.Show();
			form.Show();
		}
	}

	public class ControlPainter
	{
		private const int WM_PRINT = 0x317, PRF_CLIENT = 4, PRF_CHILDREN = 0x10, PRF_NON_CLIENT = 2, COMBINED_PRINTFLAGS = PRF_CLIENT | PRF_CHILDREN | PRF_NON_CLIENT;

		[DllImport("USER32.DLL")]
		private static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, int lParam);

		public static void PaintControl(Graphics graphics, Control control)
		{
			IntPtr hWnd = control.Handle;
			IntPtr hDC = graphics.GetHdc();

			SendMessage(hWnd, WM_PRINT, hDC, COMBINED_PRINTFLAGS);
			graphics.ReleaseHdc(hDC);
		}
	}
}