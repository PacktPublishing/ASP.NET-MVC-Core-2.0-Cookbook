using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [ResponseCache(Duration = 30)]
    public class HomeController : Controller
    {
        [ResponseCache(CacheProfileName = "Default")]
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(CacheProfileName = " Never")]
        public IActionResult NeverCachedView()
        {
            return View();
        }

        [ResponseCache(Duration = 10, Location =
                    ResponseCacheLocation.Any, NoStore = false)]
        public IActionResult About()
        {
            ViewData["Message"] =
                            "Your application description page.";
            return View();
        }

        [ResponseCache(Duration = 60, Location =
                                    ResponseCacheLocation.Client)]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }
    }
}
