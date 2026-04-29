using System;
using System.Collections.Generic;
using System.Text;

namespace LogicSystems.Business.States
{
    public class DeliveredState : IOrderState
    {
        public void Next(OrderContext context)
        {
            Console.WriteLine("Already delivered.");
        }

        public void Cancel(OrderContext context)
        {
            Console.WriteLine("Cannot cancel delivered order.");
        }
    }
}
