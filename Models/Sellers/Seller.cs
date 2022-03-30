#pragma warning disable CS8618
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorStorageSystem.Models.Sellers;

public class Seller
{
    public Seller() { }
    public Seller(string id, string name)
    {
        Id = id;
        Name = name;
    }
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("name")]
    [BsonRepresentation(BsonType.String)]
    public string Name { get; set; }
}
#pragma warning restore CS8618