using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

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
            ServiceHost sh = new ServiceHost(typeof(MyMath));

            sh.AddServiceEndpoint(
                typeof(IMyMath),
                new WSHttpBinding(),
                "http://localhost/MyMath/EndP1");

            sh.Open();
            Console.WriteLine("Push any key for exit");
            Console.ReadKey();
            sh.Close();

        }
    }
}
