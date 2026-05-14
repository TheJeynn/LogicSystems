using System;

namespace LogicSystems.Business.States
{
    public class ApprovedState : IOrderState
    {
        public void Next(OrderContext context)
        {
            Console.WriteLine("Order shipped.");
            context.SetState(new ShippedState());
        }

        public void Cancel(OrderContext context)
        {
            Console.WriteLine("Order cancelled.");
        }
    }
}