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
}
