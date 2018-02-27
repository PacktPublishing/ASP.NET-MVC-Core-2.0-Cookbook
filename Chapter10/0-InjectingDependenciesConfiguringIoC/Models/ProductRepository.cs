public interface IProductRepository
{
    int GetCountProducts();
}

public class ProductRepository : IProductRepository
{
    public int GetCountProducts()
    {
        return 10;
    }
}
