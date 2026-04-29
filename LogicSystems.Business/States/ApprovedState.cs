using System;
using System.Collections.Generic;
using System.Text;

namespace LogicSystems.Business.States
{
    public class ApprovedState : IOrderState
    {
        public void Next(OrderContext context)
        {
            Console.WriteLine("Order shipped.");
            context.State = new ShippedState();
        }

        public void Cancel(OrderContext context)
        {
            Console.WriteLine("Order cancelled.");
        }
    }
}
