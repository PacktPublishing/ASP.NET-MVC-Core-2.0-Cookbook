using Microsoft.AspNetCore.Mvc;

public class ProductController : Controller
{
    private readonly IProductRepository repo;
    public ProductController(IProductRepository repo)
    {
        this.repo = repo;
    }

    public IActionResult Index([FromServices]IProductRepository repo)
    {
        var count = repo.GetCountProducts();
        return View();
    }
}