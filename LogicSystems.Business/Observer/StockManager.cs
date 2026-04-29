using System;
using System.Collections.Generic;
using System.Text;

namespace LogicSystems.Business.Observer
{
    internal class StockManager
    {
        private List<IObserver> observers = new List<IObserver>();
        private int stock;

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void SetStock(int value)
        {
            stock = value;

            if (stock < 10)
            {
                foreach (var obs in observers)
                    obs.Update("Stock is low!");
            }
        }
    }
}
