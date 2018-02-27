using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public interface IDataRepository
{
    List<Product> GetAll();
}

public class ProductRepository : IDataRepository
{
    public List<Product> GetAll()
    {
        return null;
    }

    public List<Product> GetPromotedProducts()
    {
        return null;
}
}

public class StoredDataMiddleware
{
    RequestDelegate _next;
    IMemoryCache _cache;
    IDataRepository _repo;

    public StoredDataMiddleware(RequestDelegate next, IMemoryCache cache, IDataRepository repo)
    {
        _next = next;
        _cache = cache;
        _repo = repo;
    }

    public async Task Invoke(HttpContext context)
    {
        var products = _repo.GetAll();
        _cache.Set<List<Product>>("PromotedProducts", products);
        await context.Response.WriteAsync("I put in cache datas in a middleware \n");
        await _next.Invoke(context);
    }
}
