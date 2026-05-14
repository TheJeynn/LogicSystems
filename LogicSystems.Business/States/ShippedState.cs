using System;
using System.Collections.Generic;
using System.Text;

namespace LogicSystems.Business.States
{
    public class ShippedState : IOrderState
    {
        public void Next(OrderContext context)
        {
            Console.WriteLine("Order delivered.");
            context.SetState(new DeliveredState());
        }

        public void Cancel(OrderContext context)
        {
            Console.WriteLine("Cannot cancel, already shipped!");
        }
    }
}
