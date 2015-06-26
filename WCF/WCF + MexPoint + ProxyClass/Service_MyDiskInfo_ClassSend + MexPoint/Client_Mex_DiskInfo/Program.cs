using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client_Mex_DiskInfo.DiskInfo;

namespace Client_Mex_DiskInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            DiskInfoClient cl = new DiskInfoClient();
            MyDiskInfo disk = cl.DiskSpaces("c");

            Console.WriteLine("Information about disk {0}:", disk.DiskName);
            Console.WriteLine("\tdisk type : {0}", disk.DiskType);
            Console.WriteLine("\ttotal space : {0}", disk.TotalSpace);
            Console.WriteLine("\tfree space {0}:", disk.FreeSpace);
            Console.WriteLine();
        
            Console.WriteLine("Push any key for exit");
            Console.ReadKey();

            cl.Close();
        }
    }
}
