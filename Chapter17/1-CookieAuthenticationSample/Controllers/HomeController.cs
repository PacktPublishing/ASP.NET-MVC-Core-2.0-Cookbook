using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
	public IActionResult Index() => View();

    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
	public async Task<IActionResult> Login(LoginModel model)
	{
		if(LoginUser(model.Email, model.Password))
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Email, model.Email)
			};

			var identity = new ClaimsIdentity(claims, "login");

			var principal = new ClaimsPrincipal(identity);
			await HttpContext.SignInAsync("CookieAuthenticationScheme", principal);

			//Redirect user to home page after login.
	        return RedirectToAction(nameof(Index));
		}

		return View();
	}

	[HttpGet]
	public async Task<IActionResult> Logout()
	{
		await HttpContext.SignOutAsync("CookieAuthenticationScheme");

		return RedirectToAction(nameof(Login));
	}

	private bool LoginUser(string email, string password)
	{
		//TODO: add DB logic here
		return true;
	}
}