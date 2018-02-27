using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

public class BookController : Controller
{
    private readonly AzureStorageRepository _repository;

    public BookController(AzureStorageRepository repository)
    {
        _repository = repository;
    }
    public ActionResult Index()
    {
        var books = _repository.GetBooksFromAzureStorage()
            .AsQueryable()
            .Select(
                b => new BookViewModel
                {
                    Id = b.PartitionKey,
                    Name = b.RowKey
                })
            .OrderByDescending(b => b.Id)
            .ToList();

        return View(books);
    }
}
