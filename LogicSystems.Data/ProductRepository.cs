using LogicSystems.Core;
using System.Collections.Generic;
using System.IO;

namespace LogicSystems.Data
{
    public class ProductRepository
    {
        private readonly string filePath =
            "DataFiles/products.txt";

        public List<Product> GetAll()
        {
            var products = new List<Product>();

            if (!File.Exists(filePath))
                return products;

            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var parts = line.Split(',');

                products.Add(new Product
                {
                    Name = parts[0],
                    Stock = int.Parse(parts[1])
                });
            }

            return products;
        }

        public void Add(Product product)
        {
            string line =
                $"{product.Name},{product.Stock}";

            File.AppendAllText(
                filePath,
                line + Environment.NewLine
            );
        }
    }
}