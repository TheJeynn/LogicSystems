using System;
using System.Collections.Generic;
using LogicSystems.Core;

namespace LogicSystems.Data
{
    public class ProductRepository
    {
        private List<Product> _products = new List<Product>();

        public ProductRepository()
        {
            // Fake data
            _products.Add(new Product { Id = 1, Name = "Laptop", Price = 15000, Stock = 10 });
            _products.Add(new Product { Id = 2, Name = "Phone", Price = 8000, Stock = 20 });
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Add(Product product)
        {
            _products.Add(product);
            Console.WriteLine("Product added.");
        }

        public void UpdateStock(int productId, int newStock)
        {
            var product = _products.Find(p => p.Id == productId);
            if (product != null)
            {
                product.Stock = newStock;
                Console.WriteLine("Stock updated.");
            }
        }
    }
}