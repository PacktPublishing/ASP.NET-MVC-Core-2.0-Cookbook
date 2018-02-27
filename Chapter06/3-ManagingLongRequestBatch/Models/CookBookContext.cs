using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

public class CookBookContext : DbContext
{
    public CookBookContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Book> Book { get; set; }

    public DbSet<Recipe> Recipe { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.UseInMemoryDatabase();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Book>(entity => {
            entity.Property(e => e.Name)
                  .IsRequired()
                  .HasMaxLength(50)
                  .HasColumnType("varchar");
        });

        builder.Entity<Recipe>(entity => {
            entity.Property(e => e.Name)
                  .IsRequired()
                  .HasMaxLength(50)
                  .HasColumnType("varchar");

            entity.HasOne(d => d.IdBookNavigation)
                  .WithMany(p => p.Recipes)
                  .HasForeignKey(d => d.IdBook)
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
