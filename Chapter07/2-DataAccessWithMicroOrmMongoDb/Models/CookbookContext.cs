using MongoDB.Driver;

public class CookbookContext
{
    private readonly string connectionString = "mongodb://localhost";

    private readonly string databaseName = "CookBook";

    public IMongoDatabase Database;

    public CookbookContext()
    {
        var settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
        var client = new MongoClient(settings);
        Database = client.GetDatabase(databaseName);
    }

    public IMongoCollection<Book> Books => Database.GetCollection<Book>("Book");
}
