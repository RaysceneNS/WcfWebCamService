using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ImageSource
{
    internal class WebCamera
	{
	    private int _deviceHandle;
	    private readonly string _devicename;
	    private readonly string _deviceversion;
	    private readonly int _deviceno;

		public static WebCamera[] Devices()
		{
			var cams = new List<WebCamera>();
			for (var i = 0; i <= 10; i++)
			{
				var devicename = "".PadRight(100);
				var deviceversion = "".PadRight(100);
				var isDeviceReady = NativeMethods.CapGetDriverDescriptionA(i, ref devicename, 100, ref deviceversion, 100);
				if (!isDeviceReady)
					continue;
				cams.Add(new WebCamera(devicename, deviceversion, i));
			}
			return cams.ToArray();
		}

		public System.Drawing.Image GetImage()
		{
			NativeMethods.SendMessage(_deviceHandle, NativeMethods.WM_CAP_EDIT_COPY, 0, 0);
			var data = Clipboard.GetDataObject();
		    if (data == null)
		    {
		        return null;
		    }

		    if (data.GetDataPresent(typeof(System.Drawing.Bitmap)))
		    {
		        return (System.Drawing.Image) data.GetData(typeof (System.Drawing.Bitmap));
		    }
		    return null;
		}
		
		private WebCamera(string devicename, string deviceversion, int deviceno)
		{
			this._devicename = devicename;
			this._deviceversion = deviceversion;
			this._deviceno = deviceno;
		}

		public override string ToString()
		{
			return this._devicename + " " + this._deviceversion;
		}

	    private void StartWebCam(int height, int width, int handle)
		{
			string deviceIndex = _deviceno.ToString();

			_deviceHandle = NativeMethods.CapCreateCaptureWindowA(ref deviceIndex, NativeMethods.WS_VISIBLE | NativeMethods.WS_CHILD, 0, 0, width, height, handle, 0);

			if (NativeMethods.SendMessage(_deviceHandle, NativeMethods.WM_CAP_DRIVER_CONNECT, _deviceno, 0) > 0)
			{
				NativeMethods.SendMessage(_deviceHandle, NativeMethods.WM_CAP_SET_SCALE, -1, 0);
				NativeMethods.SendMessage(_deviceHandle, NativeMethods.WM_CAP_SET_PREVIEWRATE, 30, 0);
				NativeMethods.SendMessage(_deviceHandle, NativeMethods.WM_CAP_SET_PREVIEW, -1, 0);
			}
		}

		/// <summary>
		/// Attaches the picture box window to the webcam and begins a hardware preview.
		/// </summary>
		/// <param name="pic">The pic.</param>
		public void DisplayWebCam(PictureBox pic)
		{
			StartWebCam(pic.Height, pic.Width, (int)pic.Handle);
		}

		public void StopWebCam()
		{
			NativeMethods.SendMessage(_deviceHandle, NativeMethods.WM_CAP_DRIVER_DISCONNECT, _deviceno, 0);
		}
		
		public void ShowFormatDialog()
		{
			NativeMethods.SendMessage(this._deviceHandle, NativeMethods.WM_CAP_DLG_VIDEOFORMAT, 0, 0);
		}

		public void ShowVideoSourceDialog()
		{
			NativeMethods.SendMessage(this._deviceHandle, NativeMethods.WM_CAP_DLG_VIDEOSOURCE, 0, 0);
		}

	    private static class NativeMethods
		{
			public const int WM_CAP_DRIVER_CONNECT = 0x40a;
			public const int WM_CAP_DRIVER_DISCONNECT = 0x40b;
			public const int WM_CAP_EDIT_COPY = 0x41e;
			public const int WM_CAP_SET_PREVIEW = 0x432;
			public const int WM_CAP_SET_PREVIEWRATE = 0x434;
			public const int WM_CAP_SET_SCALE = 0x435;
			public const int WM_CAP_DLG_VIDEOFORMAT = 1065;
			public const int WM_CAP_DLG_VIDEOSOURCE = 1066;
			public const int WS_CHILD = 0x40000000;
			public const int WS_VISIBLE = 0x10000000;

			[DllImport("avicap32.dll", EntryPoint = "capGetDriverDescriptionA")]
			public static extern bool CapGetDriverDescriptionA(int wDriverIndex, [MarshalAs(UnmanagedType.VBByRefStr)]ref String ldevicename, int namelength, [MarshalAs(UnmanagedType.VBByRefStr)] ref String deviceversion, int versionlength);
			
			[DllImport("avicap32.dll", EntryPoint = "capCreateCaptureWindowA")]
			public static extern int CapCreateCaptureWindowA([MarshalAs(UnmanagedType.VBByRefStr)] ref string windowname,
				int style, int x, int y, int width, int height, int parent, int id);

			[DllImport("user32", EntryPoint = "SendMessageA")]
			public static extern int SendMessage(int hwnd, int window, int x, [MarshalAs(UnmanagedType.AsAny)] object y);
		}
	}
}
