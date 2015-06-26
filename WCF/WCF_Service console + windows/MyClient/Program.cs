using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace MyClient
{
    [ServiceContract]
    public interface IMyMath
    {
        [OperationContract]
        int Add(int a, int b);
    }


    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IMyMath> factory = new ChannelFactory<IMyMath>(
                new WSHttpBinding(),
                new EndpointAddress("http://localhost/MyMath/EndP1"));

            IMyMath chanell = factory.CreateChannel();
            int result = chanell.Add(21, 13);

            Console.WriteLine("result: {0}", result);
            Console.WriteLine("Push any key for exit");
            Console.ReadKey();
            factory.Close();

        }
    }
}
