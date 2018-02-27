using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private ICacheRedis redisCache;
    public HomeController(ICacheRedis redisCache)
    {
        this.redisCache = redisCache;
    }

    public IActionResult Index()
    {
        List<string> listColors = new List<string>
        {
            "green", "white", "black"
        };

        redisCache.Set<List<string>>("listColors", listColors);

        return View();
    }

    public IActionResult ShowCacheData()
    {
        List<string> listColors =
                    redisCache.Get<List<string>>("listColors");

        return View(listColors);
    }
}
