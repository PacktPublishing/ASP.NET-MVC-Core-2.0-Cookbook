using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

public class ProductController : Controller
{
    private readonly IProductRepository _productRepository;
    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public IActionResult Index()
    {
        var productsDtoFromRepo = _productRepository.GetProducts();
        var model = AutoMapper.Map<IEnumerable<ProductViewModel>>(productsDtoFromRepo);
        return View(model);
    }
}
