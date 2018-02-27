using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly SignInManager<ApplicationUser> _signInManager;

    public HomeController(SignInManager<ApplicationUser> signInManager) => this._signInManager = signInManager;

    public IActionResult Index() => View();

    public IActionResult Facebook()
    {
        var properties = _signInManager.ConfigureExternalAuthenticationProperties("Facebook", "/Home/FacebookOK");

        return Challenge(properties, "Facebook");
    }

    public IActionResult Google()
    {
        var properties = _signInManager.ConfigureExternalAuthenticationProperties("Google", "/Home/GoogleOK");

        return Challenge(properties, "Google");
    }

    public async Task<IActionResult> FacebookOK()
    {
        var info = await _signInManager.GetExternalLoginInfoAsync();
        //info.Principal
        //structure that holds Claims, provided by Facebook
        //it includes, Facebook Unique Identifier, Facebook Email, Facebook Name, etc.

        //info.ProviderKey
        //Facebook Unique Identifier for logged in user

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> GoogleOK()
    {
        var info = await _signInManager.GetExternalLoginInfoAsync();
        //info.Principal
        //structure that holds Claims, provided by Google
        //it includes, Google Unique Identifier, Google Email, Google Name, etc.

        //info.ProviderKey
        //Google Unique Identifier for logged in user

        return RedirectToAction(nameof(Index));
    }
}