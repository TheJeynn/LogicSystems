using LogicSystems.Business.Observer;
using System;
using System.Collections.Generic;
using System.Text;

public class SystemNotifier : IObserver
{
    public void Update(string message)
    {
        Console.WriteLine("SYSTEM: " + message);
    }
}
