using System.Collections.Generic;

namespace WebApplication.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        void Add(Product product);
        Product Find(int id);
        void Update(Product product);
        void Remove(int id);
    }
}
