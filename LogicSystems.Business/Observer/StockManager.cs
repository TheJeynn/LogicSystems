using System;
using System.Collections.Generic;
using System.Text;

namespace LogicSystems.Business.Observer
{
    public class StockManager
    {
        private List<IObserver> observers = new();
        private int stock;

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void NotifyObservers(string message)
        {
            foreach (var observer in observers)
            {
                observer.Update(message);
            }
        }

        public void SetStock(int value)
        {
            stock = value;

            if (stock < 10)
            {
                NotifyObservers("Stock is low!");
            }
        }
    }
}
