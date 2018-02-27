using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

[ViewComponent(Name = "BasketComponent")]
public class ProductController : Controller
{
    private readonly IProductRepository _productRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ProductController(IProductRepository productRepository, IHttpContextAccessor httpContextAccessor)
    {
        _productRepository = productRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var products = _productRepository.GetProducts();
        return View(products);
    }

    public IViewComponentResult Invoke()
    {
        Basket basket;
        if (_httpContextAccessor.HttpContext.Session == null)
            throw new Exception("Session is not enabled !");
        else
            basket = _httpContextAccessor.HttpContext
            .Session
            .Get<Basket>("basket");

        if (basket == null) basket = new Basket();

        return new ViewViewComponentResult()
        {
            ViewName = "BasketData",
            ViewData = new ViewDataDictionary<Basket>(ViewData, basket)
        };
    }
}
