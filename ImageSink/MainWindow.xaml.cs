using System;
using System.IO;
using System.ServiceModel;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using ImageSink.PictureServiceReference;

namespace ImageSink
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        private readonly DispatcherTimer _timer;
        private readonly PictureServiceClient _client;

        public MainWindow()
        {
            _client = new PictureServiceClient();

            _timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 0, 1)
            };
            _timer.Tick += TimerTick;
            _timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            //load the latest image from the server
            try
            {
                var result = _client.DownloadImage("key");
                if (result != null)
                {
                    DisplayImage(result);
                }
            }
            catch (EndpointNotFoundException)
            {
                //eat non response exception
            }
        }

        private void DisplayImage(byte[] result)
        {
            var bitmapImage = new BitmapImage();
            var stream = new MemoryStream(result);
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = stream;
            bitmapImage.EndInit();
            TvImage.Source = bitmapImage;
        }
    }
}
