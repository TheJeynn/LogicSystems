using System;
using System.Collections.Generic;
using System.Text;

namespace LogicSystems.Business.States
{
    public class PendingState : IOrderState
    {
        public void Next(OrderContext context)
        {
            Console.WriteLine("Order approved.");
            context.State = new ApprovedState();
        }

        public void Cancel(OrderContext context)
        {
            Console.WriteLine("Order cancelled.");
        }
    }
}
