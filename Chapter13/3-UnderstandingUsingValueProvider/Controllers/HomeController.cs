using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

public class HomeController : Controller
{
    private IProductRepository _productRepository;

    public HomeController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public IActionResult Index()
    {
        var productsDtoFromRepo = _productRepository.GetProducts();
        var model = Mapper.Map<IEnumerable<ProductViewModel>>(productsDtoFromRepo);
        return View(model);
    }

    public IActionResult GetProduct(int id)
    {
        var productDto = _productRepository.GetProduct(id);

        if (productDto == null)
        {
            return NotFound();
        }

        var productModel = Mapper.Map<ProductViewModel>(productDto);
        return Ok(productModel);
    }

    [HttpGet]
    public IActionResult AddProduct()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddProduct(ProductViewModel model)
    {
        if (ModelState.IsValid)
        {
            model.Id = _productRepository
            .GetProducts().Max(p => p.Id) + 1;

            var productDto = Mapper.Map<ProductDto>(model);

            _productRepository.AddProduct(productDto);
            return RedirectToAction("Index");
        }

        return View(model);
    }
}
