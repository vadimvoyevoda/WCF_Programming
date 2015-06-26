using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.IO;
using System.Threading;

namespace OneWay_WCFService
{
    [ServiceContract]
    public interface ICommand
    {
        [OperationContract(IsOneWay=true)]
        void SaveCommandOneWay(string commandName);

        [OperationContract]
        void SaveCommand(string commandName);
    }

    public class MyCommand : ICommand
    {
        public void SaveCommandOneWay(string commandName)
        {
            using (StreamWriter sw = new StreamWriter("CommandInfoOneWay.txt", true))
            {
                Thread.Sleep(2000);
                sw.WriteLine(String.Format("{0} - {1}",DateTime.Now, commandName));                
            }
        }

        public void SaveCommand(string commandName)
        {
            using (StreamWriter sw = new StreamWriter("CommandInfo.txt", true))
            {
                Thread.Sleep(2000);
                sw.WriteLine(String.Format("{0} - {1}", DateTime.Now, commandName));
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(MyCommand));
            
            sh.Open();
            Console.WriteLine("Push any key for exit");
            Console.ReadKey();
            sh.Close();
        }
    }
}
