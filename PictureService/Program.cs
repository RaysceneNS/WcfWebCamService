using System;
using System.ServiceModel;

namespace PictureService
{
    internal static class Program
    {
        private static void Main()
        {
            var pictureServiceHost = new ServiceHost(typeof(PictureService));
            pictureServiceHost.Open();
            Console.WriteLine("The following endpoints are created.");
            foreach (var endpointAddress in pictureServiceHost.Description.Endpoints)
            {
                Console.WriteLine(endpointAddress.Address);
            }
            Console.WriteLine("Press <Enter> to stop the service.");
            Console.ReadLine();
            
            pictureServiceHost.Close();
        }
    }
}
