using System;
using System.Collections.Generic;

[Serializable]
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

[Serializable]
public class Basket
{
    public List<Product> ListProducts { get; set; }
    public decimal Total { get; set; }

    public Basket()
    {
        ListProducts = new List<Product>();
        Total = 0;
    }
}

public interface IProductRepository
{
    IEnumerable<Product> GetProducts();
}

public class ProductRepository : IProductRepository
{
    private List<Product> _products;
    public ProductRepository()
    {
        _products = new List<Product>()
        {
            new Product { Id = 1, Name = "Laptop", Price = 250 },
            new Product { Id = 2, Name = "Phone", Price = 150 },
            new Product { Id = 3, Name = "Screen", Price = 200 }
        };
    }

    public IEnumerable<Product> GetProducts()
    {
        return _products;
    }
}
