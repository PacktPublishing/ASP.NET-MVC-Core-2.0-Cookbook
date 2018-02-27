using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly SignInManager<ApplicationUser> loginManager;

    public HomeController(ApplicationDbContext dc, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> loginManager)
    {
        this.userManager = userManager;
        this.loginManager = loginManager;

        dc.Database.EnsureCreated();
    }

    public IActionResult Index() => View();

    [HttpGet]
    public IActionResult Login() => View();

    public IActionResult Logout()
    {
        this.loginManager.SignOutAsync();

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Login(string username, string password, string rememberme)
    {
        var result = await this.loginManager.PasswordSignInAsync(username, password, rememberme == "on", false);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    public async Task<IActionResult> Register(string username, string email, string password, string phoneNumber, string cityName, DateTime jobBeginDate)
    {
        var user = new ApplicationUser()
        {
            UserName = username,
            Email = email,
            PhoneNumber = phoneNumber,
            CityName = cityName,
            JobBeginDate = jobBeginDate
        };

        var result = await this.userManager.CreateAsync(user, password);

        //TODO: check for
        //result.Succeeded and result.Errors

        return RedirectToAction(nameof(Index));
    }
}