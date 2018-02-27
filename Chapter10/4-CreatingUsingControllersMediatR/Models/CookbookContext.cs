using Microsoft.EntityFrameworkCore;

public class CookBookContext : DbContext
{
    public CookBookContext(DbContextOptions<CookBookContext> options) : base(options) { }

    public DbSet<Book> Book { get; set; }
}
public class Book
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
