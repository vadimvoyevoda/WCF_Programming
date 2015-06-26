using Client.DuplexClassClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class ClientCallback : IDuplexCallback
    {
        public void MethodClient(string str)
        {
            Console.WriteLine(str);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            ClientCallback clCallback = new ClientCallback();
            InstanceContext instCtx = new InstanceContext(clCallback);

            DuplexClient client = new DuplexClient(instCtx);
            client.Request(2000, 5);

            Console.ReadLine();
        }
    }
}
