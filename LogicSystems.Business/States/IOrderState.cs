using System;
using System.Collections.Generic;
using System.Text;

namespace LogicSystems.Business.States
{
    public interface IOrderState
    {
        void Next(OrderContext context);
        void Cancel(OrderContext context);
    }
}
