using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using MyClient.ServiceMath;

namespace MyClient
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMathClient client = new MyMathClient();
            Console.WriteLine("res = " + client.Add(9, 1));
            Console.ReadLine();
        }
    }
}
