using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

public class BookIndexViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
public class BookListIndexViewModel
{
    public List<BookIndexViewModel> BookList { get; set; }
    public string Message { get; set; }
}

public class BookListIndexQuery : IRequest
{
}

public class BookListIndexQueryHandler
{
    private readonly CookBookContext _context;
    public BookListIndexQueryHandler(CookBookContext context)
    {
        _context = context;
    }

    public async Task<BookListIndexViewModel> Handle(BookListIndexQuery query)
    {
        var books = await _context.Book.ToListAsync();
        var model = new BookListIndexViewModel
        {
            BookList = await _context.Book.ProjectTo<BookIndexViewModel>().ToListAsync()
        };
        return model;
    }
}

public class BookAddViewModel
{
    [Required(ErrorMessage = "A name is required for the book")]
    [StringLength(50, ErrorMessage = "The name of the book must not exceed 50 characters")]
    public string Name { get; set; }

    [Required(ErrorMessage = "A price is required for this book")]
    [RegularExpression(@"^\d+(\.\d{1,2})?$")]
    [Range(0.1, 100)]
    public decimal Price { get; set; }
}

public class BookAddCommand : IRequest
{
    public string Name { get; }
    public decimal Price { get; }
}

public class BookAddCommandHandler
{
    private readonly CookBookContext _context;
    public BookAddCommandHandler(CookBookContext context)
    {
        _context = context;
    }

    public async Task<Result> Handle(BookAddCommand command)
    {
        var book = new Book
        {
            Name = command.Name,
            Price = command.Price
        };

        _context.Book.Add(book);
        await _context.SaveChangesAsync();

        var result = new Result { Success = true };
        return result;
    }
}

public class Result
{
    public bool Success { get; set; }
    public string ErrorMessage { get; set; }
}
