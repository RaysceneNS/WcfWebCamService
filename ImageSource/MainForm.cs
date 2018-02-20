using System;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using ImageSource.PictureServiceReference;

namespace ImageSource
{
	public partial class MainForm : Form
	{
		private WebCamera[] _cameras;
		private WebCamera _selectedCamera;
		private readonly Timer _timer = new Timer();
		private PictureServiceClient _pictureServiceClient;
		private readonly int[] _intervals = { 1, 2, 3, 5, 10 };

		public MainForm()
		{
			InitializeComponent();

			_timer.Tick += UploadTimerTick;
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			_pictureServiceClient = new PictureServiceClient("CustomBinding_IPictureService");
			_pictureServiceClient.UploadImageCompleted += Client_UploadImageCompleted;
			_cameras = WebCamera.Devices();

			LoadIntervals();
			LoadCameraList();
		}
        
		private void LoadIntervals()
		{
			comboBoxUploadFrequency.Items.Clear();
			comboBoxUploadFrequency.Items.Add("Off");
			foreach (var interval in _intervals)
			{
				comboBoxUploadFrequency.Items.Add($"{interval} second(s)");
			}
			comboBoxUploadFrequency.SelectedIndex = 1;
		}

	    private void UploadTimerTick(object sender, EventArgs e)
		{
			// get the latest image from the select camera, if any...
		    var img = _selectedCamera?.GetImage();
			if (img == null) 
				return;

			_timer.Stop();
            
		    var stream = new MemoryStream();			
			img.Save(stream, ImageFormat.Jpeg);

			try
			{
				_pictureServiceClient.UploadImageAsync("key", stream.ToArray());
			}
			catch (Exception err)
			{
				labelMessage.Text = err.Message;
			}
		}

		/// <summary> 
		/// Returns the image codec with the given mime type 
		/// </summary> 
		private static ImageCodecInfo GetEncoderInfo(string mimeType)
		{
			// Get image codecs for all image formats 
			var codecs = ImageCodecInfo.GetImageEncoders();

			// Find the correct image codec 
			for (int i = 0; i < codecs.Length; i++)
			{
			    if (codecs[i].MimeType == mimeType)
					return codecs[i];
			}
			return null;
		}

	    private void Client_UploadImageCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
		{
			//inform
			labelMessage.Text = e.Error?.Message ?? $"Uploaded @ {DateTime.Now}";
			//begin timing for the next snapshot
			_timer.Start();
		}
		
		private void LoadCameraList()
		{
			comboBoxCamera.Items.Clear();
			bool enable;
			
			if (_cameras.Length == 0)
			{
				pictureBoxImage.Image = Properties.Resources.NoImageAvailable;
				comboBoxCamera.SelectedIndex = -1;
				enable = false;
			}
			else
			{
				foreach (var cam in _cameras)
				{
					comboBoxCamera.Items.Add(cam);
				}
				comboBoxCamera.SelectedIndex = 0;
				comboBoxCamera.DropDownStyle = ComboBoxStyle.DropDownList;
				enable = true;
			}

			buttonVideoSettings.Enabled = enable;
			comboBoxCamera.Enabled = enable;
			comboBoxUploadFrequency.Enabled = enable;
		}

		private void ComboBoxCamera_SelectedIndexChanged(object sender, EventArgs e)
		{
		    _selectedCamera?.StopWebCam();

		    // fire up the selected cam
			if (comboBoxCamera.SelectedIndex < 0 || comboBoxCamera.SelectedIndex >= _cameras.Length)
				return;

			_selectedCamera = _cameras[comboBoxCamera.SelectedIndex];
			_selectedCamera.DisplayWebCam(pictureBoxImage);
		}

		private void ComboBoxSnapshotInterval_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBoxUploadFrequency.SelectedIndex <= 0)
				_timer.Stop();
			else
			{
				_timer.Interval = _intervals[comboBoxUploadFrequency.SelectedIndex-1]*1000;
				_timer.Start();
			}
		}

		private void Button1_Click(object sender, EventArgs e)
		{
		    _selectedCamera?.ShowFormatDialog();
		}
    }
}
