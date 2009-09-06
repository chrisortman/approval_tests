using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ApprovalTests.Core;

namespace ApprovalTests.Writers
{
	class ApprovalWpfWindowWriter: IApprovalWriter
	{
		private readonly Window window;

		public ApprovalWpfWindowWriter(Window window)
		{
			this.window = window;
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
			window.Show(); // make sure it is ready for rendering

			// The BitmapSource that is rendered with a Visual.
			var rtb = new RenderTargetBitmap((int)window.ActualWidth, (int)window.ActualHeight, 96, 96, PixelFormats.Pbgra32);
			rtb.Render(window);

			// Encoding the RenderBitmapTarget as a PNG file.
			var png = new PngBitmapEncoder();
			png.Frames.Add(BitmapFrame.Create(rtb));
			using (Stream stm = File.Create(received))
			{
				png.Save(stm);
			}
			return received;
		}

	}
}
