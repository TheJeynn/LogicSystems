using LogicSystems.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicSystems.Business.States
{
    public class ReturnedState : IOrderState
    {
        public void Next(OrderContext context)
        {
            Console.WriteLine("Returned order cannot continue.");
        }

        public void Cancel(OrderContext context)
        {
            Console.WriteLine("Order already returned.");
        }
    }
}
