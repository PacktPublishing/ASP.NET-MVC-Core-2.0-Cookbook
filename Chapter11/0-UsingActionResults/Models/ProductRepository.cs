using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class ProductRepository : IProductRepository
    {
        public void Add(Product product)
        {
        }

        public Product Find(int id)
        {
            return new Product();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return new List<Product>() {
                new Product() { Id = 1, Name = "Phone", Price = 500, StockCount = 5 },
                new Product() { Id = 2, Name = "Laptop", Price = 1200, StockCount = 9 },
                new Product() { Id = 3, Name = "Screen", Price = 400, StockCount = 3 },
                new Product() { Id = 4, Name = "Mouse", Price = 30, StockCount = 16 }
            };
        }

        public void Remove(int id)
        {
        }

        public void Update(Product product)
        {
        }
    }
}
