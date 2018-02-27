using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
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

        [HttpPost]
        public IActionResult Create(Product product)
        {
            return View();
        }

        public async Task<IActionResult> PostToApiCtrl(Product product)
        {
            if (Request.ContentType == "application/x-www-form-urlencoded; charset=UTF-8")
            {
                IFormCollection jqFormData = await Request.ReadFormAsync();
            }
            return Ok();
        }

        public IActionResult PostFormMvc([FromForm]string name)
        {
            return View();
        }
    }
}
