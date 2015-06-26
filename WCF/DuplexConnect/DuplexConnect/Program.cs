using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DuplexConnect
{
    [ServiceContract(CallbackContract=typeof(IClientCallback))]
    public interface IDuplex
    {
        [OperationContract(IsOneWay=true)]
        void Request(int period, int num);
    }

    public class DuplexCl : IDuplex
    {
        public void Request(int period, int num)
        {
            OperationContext.Current.GetCallbackChannel<IClientCallback>().MethodClient(DateTime.Now.ToLongTimeString());
            
            //ClientCaller caller = new ClientCaller(OperationContext.Current.GetCallbackChannel<IClientCallback>());
            
            //ParameterizedThreadStart threadStart = new ParameterizedThreadStart(caller.SendDataToClient);
            //Thread thread = new Thread(threadStart);
            //thread.IsBackground = true;
                        
            //thread.Start(Tuple.Create(period, num));
        }
    }

    public interface IClientCallback
    {
        [OperationContract(IsOneWay = true)]
        void MethodClient(string str);
    }

    //public class ClientCaller
    //{
    //    private IClientCallback callback;

    //    public ClientCaller(IClientCallback call)
    //    {
    //        callback = call;
    //    }
        
    //    public void SendDataToClient(object a)
    //    {
    //        if (a is Tuple<int, int>)
    //        {
    //            Tuple<int, int> param = (a as Tuple<int, int>);
                
    //            for (int i = 0; i < param.Item2; i++)
    //            {
    //                Thread.Sleep(param.Item1);
    //                try
    //                {
    //                    callback.MethodClient(DateTime.Now.ToLongTimeString());
    //                }
    //                catch (Exception exc)
    //                {
    //                }
    //            }

    //            callback.MethodClient("The end!");
    //        }
            
    //    }
    //}
    


    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(DuplexCl));

            sh.Open();
            Console.WriteLine("Push anything to exit");
            Console.ReadLine();

            sh.Close();
        }
    }
}
