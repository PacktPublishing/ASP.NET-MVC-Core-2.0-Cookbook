using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Book
{
    [BsonRepresentation(BsonType.ObjectId)]
    public int Id { get; set; }
    public string Name { get; set; }
}
