using System.Collections.Generic;
using System.Linq;

public class ProductDataStore
{
    public static ProductDataStore Current { get; } = new ProductDataStore();

    public List<ProductDto> Products { get; set; }

    public ProductDataStore()
    {
        Products = new List<ProductDto>()
        {
            new ProductDto { Id = 1, Name = "Laptop" },
            new ProductDto { Id = 2, Name = "Phone" },
            new ProductDto { Id = 3, Name = "Desktop" }
        };
    }
}

public interface IProductRepository
{
    ProductDto GetProduct(int id);
    IEnumerable<ProductDto> GetProducts();
    void AddProduct(ProductDto productDto);
}

public class ProductRepository : IProductRepository
{
    public List<ProductDto> Products
    {
        get
        {
            return ProductDataStore.Current.Products;
        }
    }

    public IEnumerable<ProductDto> GetProducts()
    {
        return Products.AsEnumerable();
    }

    public ProductDto GetProduct(int id)
    {
        return Products.Where(p => p.Id == id).SingleOrDefault();
    }

    public void AddProduct(ProductDto productDto)
    {
        Products.Add(productDto);
    }
}
