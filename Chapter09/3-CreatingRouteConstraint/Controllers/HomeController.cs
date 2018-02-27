using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    // for an api controller
    [Route("api/[controller]")]
    public class ProductValuesController : Controller
    {
        // GET api/productvalues/5 
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // PUT api/productvalues/laptop
        [HttpPut("{name:alpha:length(3)}")]
        public void UpdateProductName(string name) { }
    }
    // for a MVC controller
    [Route("[controller]")]
    public class HomeController : Controller
    {
        // GET home/index/5 
        [Route("{id?}")]
        public IActionResult Index(int? id) { return View(); }


        [Route("{name:alpha:length(3)}")]
        public IActionResult UpdateProductName(string name)
        { return View(); }
    }
}
