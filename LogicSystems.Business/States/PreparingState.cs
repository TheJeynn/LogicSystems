using LogicSystems.Core;
using System;
using System.Collections.Generic;
using System.Text;


namespace LogicSystems.Business.States
{
    public class PreparingState : IOrderState
    {
        public void Next(OrderContext context)
        {
            context.State = new ShippedState();
        }

        public void Cancel(OrderContext context)
        {
            context.State = new ReturnedState();
        }
    }
}