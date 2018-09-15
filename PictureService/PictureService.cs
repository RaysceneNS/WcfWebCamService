using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel;

namespace PictureService
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class PictureService : IPictureService
    {
        private readonly Dictionary<string, byte[]> _imageCache = new Dictionary<string, byte[]>();
        
        public void UploadImage(FileUploadMessage message)
        {
            Debug.WriteLine($"{DateTime.Now} Upload image, {message.FileBytes.Length} bytes.");

            lock (_imageCache)
            {
                if (_imageCache.ContainsKey(message.Key))
                {
                    _imageCache[message.Key] = message.FileBytes;
                }
                else
                {
                    _imageCache.Add(message.Key, message.FileBytes);
                }
            }
        }

        public byte[] DownloadImage(string key)
        {
            byte[] buffer = null;
            lock (_imageCache)
            {
                if (_imageCache.ContainsKey(key))
                {
                    buffer = _imageCache[key];
                }
            }
            return buffer;
        }
    }
}
