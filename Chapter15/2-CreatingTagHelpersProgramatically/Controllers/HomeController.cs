using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new List<MenuElement>()
            {
                new MenuElement
                {
                    Name = "Home",
                    Controller = "Home",
                    Action = "Index"
                },
                new MenuElement
                {
                    Name = "About",
                    Controller = "Home",
                    Action = "About"
                },
                new MenuElement
                {
                    Name = "Contact",
                    Controller = "Home",
                    Action = "Contact"
                }
            };

            return View(model);
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
