using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client_Mex_DiskInfo.MyDiskInfo;

namespace Client_Mex_DiskInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            DiskInfoClient cl = new DiskInfoClient();
            string freeC = cl.FreeSpace("c");
            string totalC = cl.TotalSpace("c");

            Console.WriteLine("Info about disk C:\n Total Space:{0}\n Free Space:{1}\n",freeC, totalC);
            Console.WriteLine("Push any key for exit");
            Console.ReadKey();

            cl.Close();
        }
    }
}
