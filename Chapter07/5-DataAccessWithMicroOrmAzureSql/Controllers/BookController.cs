using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

public class BookController : Controller
{
    private readonly CookbookContext _context;
    public BookController(CookbookContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        List<Book> books = _context.Books.ToList();

        return View(books);
    }
}
