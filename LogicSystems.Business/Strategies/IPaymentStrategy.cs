using System;
using System.Collections.Generic;
using System.Text;

namespace LogicSystems.Business.Strategies
{
    public interface IPaymentStrategy
    {
        void Pay(decimal amount);
    }
}
