using System;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ApprovalTests.Core;

namespace ApprovalTests.Wpf
{
    public class WindowWpfWriter : IApprovalWriter
    {

        public delegate T Loader<T>();
        private readonly Loader<Window> Action;

        public WindowWpfWriter(Loader<Window> action)
        {
            Action = action;
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
            bool w = false;
            var t = new Thread(() =>
                                   {
                                       Window window = Action.Invoke();
                                       ScreenCapture(window, received);

                                       w = true;
                                   });
            t.SetApartmentState(ApartmentState.STA); //Many WPF UI elements need to be created inside STA
            t.Start();
            while (!w)
            {
                Thread.Sleep(10);
            }

            return received;
        }

        #endregion

        public static void ScreenCapture(Window window, string filename)
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
    }
}