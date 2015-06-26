using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace MyServer1
{
    [ServiceContract]
    public interface IMyMath
    {
        [OperationContract]
        int Add(int a, int b);
    }

    public class MyMath : IMyMath
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(MyMath), new Uri("http://localhost/MyMath"));

            /* find in App.config

            sh.AddServiceEndpoint(
                typeof(IMyMath),
                new WSHttpBinding(),
                "http://localhost/MyMath/EndP1");
             
             */

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
