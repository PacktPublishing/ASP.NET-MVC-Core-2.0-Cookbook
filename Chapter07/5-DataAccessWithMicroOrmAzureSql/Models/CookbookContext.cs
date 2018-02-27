using Microsoft.EntityFrameworkCore;

public class CookbookContext : DbContext
{
    public CookbookContext(DbContextOptions<CookbookContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
}