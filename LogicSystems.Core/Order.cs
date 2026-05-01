using System;
using System.Collections.Generic;

namespace LogicSystems.Core
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public List<Product> Products { get; set; }
        public decimal TotalPrice { get; set; }

        public Order()
        {
            Products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
            TotalPrice += product.Price;
        }

        public void DisplayOrder()
        {
            Console.WriteLine($"Order ID: {Id}");
            Console.WriteLine($"Customer: {CustomerName}");
            Console.WriteLine($"Total Price: {TotalPrice}");
        }
    }
}