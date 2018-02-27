using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        [TypeFilter(typeof(MyActionFilter))]
        [ServiceFilter(typeof(MyActionFilter))]
        [MyActionTypeFilterAttribute]
        [ServiceFilter(typeof(MyAsyncResultFilter))]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = "AuthPolicyAuthentication")]
        public IActionResult About()
        {
            if (User.Identity.IsAuthenticated)
                RedirectToAction("Index");

            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
