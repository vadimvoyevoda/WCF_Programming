using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Client_MyDiskInfo
{
    [ServiceContract]
    public interface IDiskInfo
    {
        [OperationContract]
        string FreeSpace(string diskName);

        [OperationContract]
        string TotalSpace(string diskName);
    }

    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IDiskInfo> factory = new ChannelFactory<IDiskInfo>(
                new WSHttpBinding(),
                new EndpointAddress("http://localhost/DiskInfo/EndP1"));

            IDiskInfo chanell = factory.CreateChannel();
            string diskName = "D";
            string totalSpace = chanell.TotalSpace(diskName);
            string freeSpace = chanell.FreeSpace(diskName);

            Console.WriteLine("Disk {0}: \nTotal Space: {1}\nFree Space: {2}", diskName, totalSpace, freeSpace);
            Console.WriteLine("Push any key for exit");
            Console.ReadKey();
            
            factory.Close();
        }
    }
}
