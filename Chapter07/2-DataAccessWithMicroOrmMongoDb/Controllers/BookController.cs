using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MongoDB.Driver;

public class BookController : Controller
{
    private readonly CookbookContext _context;

    public BookController(CookbookContext context)
    {
        _context = context;
    }
    public async Task<ActionResult> Index()
    {
        var books = await _context.Books.AsQueryable()
            .Select(
                b => new BookViewModel
                {
                    Id = b.Id,
                    Name = b.Name
                })
            .OrderByDescending(b => b.Id)
            .ToListAsync();

        return View(books);
    }
}
