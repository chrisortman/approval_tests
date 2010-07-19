using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ApprovalTests.Core;

namespace ApprovalTests.Wpf
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
            WindowWpfWriter.ScreenCapture(window, received);
			return received;
		}

	}
}
