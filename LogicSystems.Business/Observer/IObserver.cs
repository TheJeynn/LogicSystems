using System;
using System.Collections.Generic;
using System.Text;

namespace LogicSystems.Business.Observer
{
    internal interface IObserver
    {
        void Update(string message);
    }
}
