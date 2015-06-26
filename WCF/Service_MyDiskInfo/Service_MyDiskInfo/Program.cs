using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.IO;
using System.ServiceModel.Description;

namespace Service_MyDiskInfo
{
    [ServiceContract]
    public interface IDiskInfo
    {
        [OperationContract]
        string FreeSpace(string diskName);

        [OperationContract]
        string TotalSpace(string diskName);
    }

    public class DiskInfo : IDiskInfo
    {
        public string FreeSpace(string diskName)
        {
            if (Directory.GetLogicalDrives().Contains(String.Format("{0}:\\", diskName.ToUpper())))
            {
                DriveInfo di = new DriveInfo(diskName);
                return String.Format("{0} MB", di.TotalFreeSpace / 1024 / 1024);
            }
            else
            {
                return "Sorry, disk is not available";
            }
        }

        public string TotalSpace(string diskName)
        {            
            if (Directory.GetLogicalDrives().Contains( String.Format("{0}:\\", diskName.ToUpper())))
            {
                DriveInfo di = new DriveInfo(diskName);
                return String.Format("{0} MB", di.TotalSize/1024/1024);
            }
            else
            {
                return "Sorry, disk is not available";
            }
          
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(DiskInfo), new Uri("http://localhost/DiskInfo"));
           
            ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
            behavior.HttpGetEnabled = true;

            sh.Description.Behaviors.Add(behavior);
            sh.AddServiceEndpoint(
                typeof(IMetadataExchange),
                MetadataExchangeBindings.CreateMexHttpBinding(),
                "mex");

            sh.Open();
            Console.WriteLine("Push any key for exit");
            Console.ReadKey();
            sh.Close();
        }
    }
}
