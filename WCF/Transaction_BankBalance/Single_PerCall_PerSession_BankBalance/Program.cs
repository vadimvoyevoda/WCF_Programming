using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Single_PerCall_PerSession_BankBalance
{
    [ServiceContract(SessionMode=SessionMode.Required)]
    public interface IBankBalance
    {
        [OperationContract]        
        void ToBalance(double sum);

        [OperationContract]
        double getBalance();
    }

    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]  // - balance one for session(application)
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]     // - balance always 0, one instance on one request
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode=ConcurrencyMode.Multiple)]        // - balance one for all session(application)
    public class BankBalance : IBankBalance
    {
        static int amount = 0;
        double balance;

        public BankBalance()
        {
            amount++;
            Console.WriteLine("Create amount with number {0}", amount);
        }

        //[OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = false)]
        public void ToBalance(double sum)
        {
            balance += sum;
            //OperationContext.Current.SetTransactionComplete();
            //getBalance();
        }

        //[OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public double getBalance()
        {
            return balance;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(BankBalance));

            sh.Open();
            Console.WriteLine("Waiting");
            Console.ReadLine();

            sh.Close();
        }
    }
}
