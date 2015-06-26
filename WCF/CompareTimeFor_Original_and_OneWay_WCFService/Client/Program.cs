using Client.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandClient client = new CommandClient();
            
            Stopwatch sw = Stopwatch.StartNew();
            client.SaveCommand("Loading");
            Console.WriteLine("Time = {0}", sw.ElapsedMilliseconds);

            Stopwatch sw2 = Stopwatch.StartNew();
            client.SaveCommandOneWay("Loading");
            Console.WriteLine("Time One Way = {0}", sw2.ElapsedMilliseconds);
        }
    }
}
