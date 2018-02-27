using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly IProductRepository _productRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HomeController(IProductRepository productRepository, IHttpContextAccessor httpContextAccessor)
    {
        _productRepository = productRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddToBasket(int id)
    {
        var basket = _httpContextAccessor.HttpContext
        .Session.Get<Basket>("basket");

        if (basket == null) basket = new Basket();

        var product = _productRepository.GetProducts().Where(p => p.Id == id).SingleOrDefault();

        basket.ListProducts.Add(product);
        basket.Total += product.Price;

        _httpContextAccessor.HttpContext.Session.Set("basket", basket);

        return NoContent();
    }
}
