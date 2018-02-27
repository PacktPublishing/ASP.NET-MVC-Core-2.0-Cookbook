using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Dapper;

public class BookController : Controller
{
    private readonly IDbConnection _db;
    public BookController(IDbConnection db)
    {
        _db = db;
    }

    public IActionResult Index()
    {
        List<Book> books = _db.Query<Book>("GetAllCookbooks", commandType: CommandType.StoredProcedure).ToList();

        return View(books);
    }
}
