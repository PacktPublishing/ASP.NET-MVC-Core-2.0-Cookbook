using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly IOperationTransient _transient;
    private readonly IOperationScoped _scoped;
    private readonly IOperationSingleton _singleton;
    private readonly IOperationInstance _instance;

    public HomeController(IOperationTransient transient, IOperationScoped scoped, IOperationSingleton singleton, IOperationInstance instance)
    {
        this._transient = transient;
        this._scoped = scoped;
        this._singleton = singleton;
        this._instance = instance;
    }

    public IActionResult Index()
    {
        ViewBag.Transient = this._transient;
        ViewBag.Scoped = this._scoped;
        ViewBag.Singleton = this._singleton;
        ViewBag.Instance = this._instance;

        return View();
    }
}