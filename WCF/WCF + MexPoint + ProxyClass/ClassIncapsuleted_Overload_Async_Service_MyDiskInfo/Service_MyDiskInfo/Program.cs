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
    public enum UserType
    {
        [EnumMember]
        Student,
        [EnumMember]
        Teacher,
        [EnumMember]
        Admin,
        [EnumMember]
        Unknown
    }
    [DataContract]
    public class User
    {
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public UserType type { get; set; }
        [DataMember]
        public DateTime Date { get; set; }        
    }
    [DataContract]
    public class MyDiskInfo
    {
        [DataMember]
        public string DiskName { get; set; }
        [DataMember]
        public DriveType DiskType { get; set; }
        [DataMember]
        public string TotalSpace { get; set; }
        [DataMember]
        public string FreeSpace { get; set; }
        [DataMember]
        public string AvailableFreeSpace { get; set; }
        [DataMember]
        public User user{ get; set; }
    }


    [ServiceContract]
    public interface IDiskInfo
    {
        [OperationContract]
        MyDiskInfo DiskSpaces(string diskName);
        [OperationContract]
        MyDiskInfo DiskSpacesWithDescription(string diskName, string description); 
    }

    public class DiskInfo : IDiskInfo
    {
        public MyDiskInfo DiskSpaces(string diskName)
        {
            MyDiskInfo mdi;
            if (Directory.GetLogicalDrives().Contains(String.Format("{0}:\\", diskName.ToUpper())))
            {
                DriveInfo di = new DriveInfo(diskName);
                mdi = new MyDiskInfo()
                {
                    DiskName = di.Name,
                    FreeSpace = String.Format("{0:0.00} GB", (double)di.TotalFreeSpace / 1024 / 1024 / 1024),
                    AvailableFreeSpace = String.Format("{0:0.00} GB", (double)di.AvailableFreeSpace / 1024 / 1024 / 1024),
                    TotalSpace = String.Format("{0:0.00} GB", (double)di.TotalSize / 1024 / 1024 / 1024),
                    DiskType = di.DriveType
                };
                mdi.user = new User()
                {
                    Login = System.Security.Principal.WindowsIdentity.GetCurrent().Name,
                    Date = DateTime.Now,
                    type = UserType.Student
                };           
            }
            else
            {
                mdi = new MyDiskInfo()
                {
                    user = new User()
                        {
                            Login = System.Security.Principal.WindowsIdentity.GetCurrent().Name,
                            Date = DateTime.Now,
                            type = UserType.Unknown
                        }

                };                
            }
            return mdi;
        }

        public MyDiskInfo DiskSpacesWithDescription(string diskName, string description)
        {
            MyDiskInfo mdi;
            if (Directory.GetLogicalDrives().Contains(String.Format("{0}:\\", diskName.ToUpper())))
            {
                DriveInfo di = new DriveInfo(diskName);
                mdi = new MyDiskInfo()
                {
                    DiskName = di.Name,
                    FreeSpace = String.Format("{0:0.00} GB", (double)di.TotalFreeSpace / 1024 / 1024 / 1024),
                    AvailableFreeSpace = String.Format("{0:0.00} GB", (double)di.AvailableFreeSpace / 1024 / 1024 / 1024),
                    TotalSpace = String.Format("{0:0.00} GB", (double)di.TotalSize / 1024 / 1024 / 1024),
                    DiskType = di.DriveType
                };
                mdi.user = new User()
                {
                    Login = System.Security.Principal.WindowsIdentity.GetCurrent().Name,
                    Date = DateTime.Now,
                    type = UserType.Student
                };
            }
            else
            {
                mdi = new MyDiskInfo()
                {
                    user = new User()
                    {
                        Login = System.Security.Principal.WindowsIdentity.GetCurrent().Name,
                        Date = DateTime.Now,
                        type = UserType.Unknown
                    }

                };
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
