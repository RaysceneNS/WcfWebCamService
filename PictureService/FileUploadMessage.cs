using System.ServiceModel;

namespace PictureService
{
    [MessageContract]
    public class FileUploadMessage
    {
        [MessageBodyMember(Order = 0)]
        public string Key;
        
        [MessageBodyMember(Order = 1)]
        public byte[] FileBytes;
    }
}