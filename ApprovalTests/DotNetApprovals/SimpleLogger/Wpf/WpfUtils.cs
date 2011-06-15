using System;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ApprovalTests.Wpf
{
	public class WpfUtils
	{
		public static void ScreenCapture(Window window, string filename)
		{
			try
			{
				window.Show(); // make sure it is ready for rendering

				// The BitmapSource that is rendered with a Visual.
				var rtb = new RenderTargetBitmap((int)window.ActualWidth, (int)window.ActualHeight, 96, 96, PixelFormats.Pbgra32);
				rtb.Render(window);

				// Encoding the RenderBitmapTarget as a PNG file.
				var png = new PngBitmapEncoder();
				png.Frames.Add(BitmapFrame.Create(rtb));
				using (Stream stm = File.Create(filename))
				{
					png.Save(stm);
				}
			}
			finally
			{
				window.Close();
			}
		}

		public static string ScreeenCaptureInStaThread(string received, Func<Window> loader)
		{
			Exception caught = null;
			var t = new Thread(() =>
			                   	{
			                   		try
			                   		{
			                   			Window window = loader();
			                   			ScreenCapture(window, received);
			                   		}
			                   		catch (Exception e)
			                   		{
			                   			caught = e;
			                   		}
			                   	});

			t.SetApartmentState(ApartmentState.STA); //Many WPF UI elements need to be created inside STA
			t.Start();
			t.Join();

			if (caught != null)
			{
				throw new Exception("Creating window failed.", caught);
			}

			return received;
		}
	}
}