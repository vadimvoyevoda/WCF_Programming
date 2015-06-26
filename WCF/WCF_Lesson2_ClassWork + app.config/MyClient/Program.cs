using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using MyClient.MexClass;

namespace MyClient
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMathClient MathClient = new MyMathClient();

            int result = MathClient.Add(21, 13);

            Console.WriteLine("result: {0}", result);
            Console.WriteLine("Push any key for exit");
            Console.ReadKey();

            MathClient.Close();
        }
    }
}
