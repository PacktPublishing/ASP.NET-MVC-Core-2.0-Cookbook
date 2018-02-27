using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class BookController : Controller
{
    private readonly IMediator _mediator;
    public BookController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public IActionResult Index(BookListIndexQuery query)
    {
        var model = _mediator.Send(query);
        return View(model);
    }
}
