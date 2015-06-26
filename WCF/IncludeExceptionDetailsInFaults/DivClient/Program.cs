using DivClient.DivMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivClient
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMathClient client = new MyMathClient();
            client.Div(32, 0);

            Console.WriteLine("Press any key");
            Console.ReadLine();
        }
    }
}
