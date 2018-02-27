using System.Collections.Generic;

public class ProductService : IProductService
{
    public List<Product> GetSomeProducts()
    {
        return new List<Product>() {
            new Product() { Id = 1, Name = "Laptop", Price = 320.0D },
            new Product() { Id = 2, Name = "Smartphone", Price = 206.0D },
        };
    }
}