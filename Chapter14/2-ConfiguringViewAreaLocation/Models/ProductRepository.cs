using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

public class ProductViewModel
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [Range(0.01, double.MaxValue,
    ErrorMessage = "Please enter a positive number")]
    public decimal Price { get; set; }
}

public interface IProductRepository
{
    IEnumerable<ProductDto> GetProducts();
}

public class ProductRepository : IProductRepository
{
    private List<ProductDto> _products;
    public ProductRepository()
    {
        _products = new List<ProductDto>()
        {
            new ProductDto { Id = 1, Name = "Laptop" },
            new ProductDto { Id = 2, Name = "Phone" },
            new ProductDto { Id = 3, Name = "Desktop" }
        };
    }
    public IEnumerable<ProductDto> GetProducts()
    {
        return _products.AsEnumerable();
    }
}
