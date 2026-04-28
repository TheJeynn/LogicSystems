using System;
using System.Collections.Generic;
using System.Text;

namespace LogicSystems.Business.Strategies
{
    public class BankTransferPayment : IPaymentStrategy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount} TL via Bank Transfer.");
        }
    }
}
