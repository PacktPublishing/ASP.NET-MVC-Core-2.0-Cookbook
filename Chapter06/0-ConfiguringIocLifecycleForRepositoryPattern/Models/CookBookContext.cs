using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class CookBookContext : DbContext
{
	public CookBookContext()
	{
		var config = new ConfigurationBuilder()
			.AddJsonFile("appsettings.json")
			.AddEnvironmentVariables();

		Configuration = config.Build();
	}

	public IConfiguration Configuration { get; set; }

	public DbSet<Book> Books { get; set; }
	public DbSet<Recipe> Recipes { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder options)
	{
		var connectionString = Configuration["Data:DefaultConnection:ConnectionString"];
		options.UseSqlServer(connectionString);
	}
}
