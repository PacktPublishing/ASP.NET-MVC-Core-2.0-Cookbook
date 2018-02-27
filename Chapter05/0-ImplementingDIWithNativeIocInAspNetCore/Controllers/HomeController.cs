using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly IProductService _service;

    public HomeController(IProductService service)
    {
        this._service = service;
    }

    public IActionResult Index()
    {
        var model = this._service.GetSomeProducts();

        return View(model);
    }
}