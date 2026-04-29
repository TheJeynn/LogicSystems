using LogicSystems.Business.States;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicSystems.Business
{
    public class OrderContext
    {
        public IOrderState State { get; set; }

        public OrderContext(IOrderState state)
        {
            State = state;
        }

        public void Next()
        {
            State.Next(this);
        }

        public void Cancel()
        {
            State.Cancel(this);
        }
    }
}
