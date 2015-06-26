using BankClient.BankBalance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClient
{
    class Program
    {
        static void Main(string[] args)
        {
            BankBalanceClient client = new BankBalanceClient();
            client.ToBalance(1000);
            Console.WriteLine("My balance = " + client.getBalance());
        }
    }
}
