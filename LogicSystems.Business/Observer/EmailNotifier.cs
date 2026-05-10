using System;
using System.Collections.Generic;
using System.Text;

namespace LogicSystems.Business.Observer
{
    public class EmailNotifier : IObserver
    {
        public void Update(string message)
        {
            Console.WriteLine("EMAIL: " + message);
        }
    }
}
