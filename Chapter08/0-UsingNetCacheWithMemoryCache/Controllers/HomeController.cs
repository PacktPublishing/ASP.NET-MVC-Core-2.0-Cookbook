using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMemoryCache cache;
        public HomeController(IMemoryCache cache)
        {
            this.cache = cache;
        }

        public IActionResult Index()
        {
            var strToCache = "Hello from cache";
            DateTime absoluteExpiration = DateTime.Now.AddDays(1);
            DateTimeOffset expirationFromNow = DateTime.UtcNow.AddDays(1);

            cache.Set<string>("str1", strToCache);
            cache.Set<string>("str1", strToCache, absoluteExpiration);
            cache.Set<string>("str1", strToCache, expirationFromNow);

            var listColors = new List<string>
            {
                "green", "white", "black"
            };
            cache.Set<List<string>>("listColors", listColors);

            return View();
        }

        public IActionResult TryShowCachedData()
        {
            var str1 = cache.Get<string>("str1");

            var listColors = cache.Get<List<string>>("listColors");

            List<string> listStrings = null;
            bool dataExist = cache.TryGetValue<List<string>>("lstStr", out listStrings);

            if (!dataExist)
                listStrings = new List<string>();

            return View(listStrings);
        }

        public IActionResult About()
        {
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
