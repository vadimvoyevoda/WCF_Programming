using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.IO;
using System.ServiceModel.Description;
using System.Runtime.Serialization;

namespace Service_MyDiskInfo
{
    [DataContract]
    public class MyDiskInfo
    {
        [DataMember]
        public string DiskName { get; set; }
        [DataMember]
        public DriveType DiskType { get; set; }
        [DataMember]
        public long TotalSpace { get; set; }
        [DataMember]
        public long FreeSpace { get; set; }
    }


    [ServiceContract]
    public interface IDiskInfo
    {
        [OperationContract]
        MyDiskInfo DiskSpaces(string diskName);
        [OperationContract]
        void Print(MyDiskInfo mdi);
    }

    public class DiskInfo : IDiskInfo
    {
        public MyDiskInfo DiskSpaces(string diskName)
        {
            MyDiskInfo mdi;
            if (Directory.GetLogicalDrives().Contains(String.Format("{0}:\\", diskName.ToUpper())))
            {
                DriveInfo di = new DriveInfo(diskName);
                mdi = new MyDiskInfo() { DiskName=di.Name, FreeSpace = di.TotalFreeSpace, TotalSpace = di.TotalSize, DiskType = di.DriveType };               
            }
            else
            {
                mdi = new MyDiskInfo() { DiskName = "notAvailable", FreeSpace = -1, TotalSpace = -1, DiskType = DriveType.Unknown };                
            }
            return mdi;
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
