using System;
using System.Collections.Generic;
using System.Text;

namespace LogicSystems.Core
{
    public class Computer : Product
    {
        public List<Product> Parts { get; set; }

        public Computer()
        {
            Parts = new List<Product>();
        }

        public void AddPart(Product product)
        {
            Parts.Add(product);
        }
    }
}
