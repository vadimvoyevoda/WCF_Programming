using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client_Mex_DiskInfoAsync.DiskInfoAsync;

namespace Client_Mex_DiskInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            DiskInfoClient dic = new DiskInfoClient();
            dic.BeginDiskSpaces("d", new AsyncCallback(OnResult), dic);

            Console.ReadKey();
            dic.Close();
        }

        private static void OnResult(IAsyncResult res)
        {
            var disk = (res.AsyncState as DiskInfoClient);
            MyDiskInfo mdi = disk.EndDiskSpaces(res);

            Print(mdi);
        }

        static void Print(MyDiskInfo disk)
        {
            Console.WriteLine("Information about disk {0}:", disk.DiskName);
            Console.WriteLine("\tdisk type : {0}", disk.DiskType);
            Console.WriteLine("\ttotal space : {0}", disk.TotalSpace);
            Console.WriteLine("\tfree space : {0}", disk.FreeSpace);
            Console.WriteLine("\tavailable free space : {0}\n", disk.AvailableFreeSpace);
            Console.WriteLine("\tuserLogin : {0}", disk.user.Login);
            Console.WriteLine("\tuserType : {0}", disk.user.type);
            Console.WriteLine("\tdate : {0}", disk.user.Date);
            Console.WriteLine("\tExtensionData : {0}", disk.user.ExtensionData);
            Console.WriteLine();
            Console.WriteLine("Push any key for exit");            
        }


    }
}
