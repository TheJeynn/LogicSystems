using System;
using System.Collections.Generic;
using System.Text;

namespace LogicSystems.Business.Strategies
{
    public class CreditCardPayment : IPaymentStrategy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid {amount} TL using Credit Card.");
        }
    }
}
