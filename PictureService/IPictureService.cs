using System.ServiceModel;

namespace PictureService
{
	[ServiceContract]
	public interface IPictureService
	{
		[OperationContract(IsOneWay = true)]
		void UploadImage(FileUploadMessage message);
        
		[OperationContract]
		byte[] DownloadImage(string key);
	}

	[MessageContract]
	public class FileUploadMessage
	{
	    [MessageBodyMember(Order = 0)]
	    public string Key;
        
        [MessageBodyMember(Order = 1)]
		public byte[] FileBytes;
	}
}
