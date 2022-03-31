#pragma warning disable CS8618
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorStorageSystem.Models.Sellers;

public class Seller
{
    public Seller()
    {
    }
    public Seller(string id, string name, string address, string phone)
    {
        Id = id;
        Name = name;
        Address = address;
        Phone = phone;
    }
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("name")]
    [BsonRepresentation(BsonType.String)]
    public string Name { get; set; }
    [BsonElement("address")]
    [BsonRepresentation(BsonType.String)]
    public string Address { get; set; }
    [BsonElement("phone")]
    [BsonRepresentation(BsonType.String)]
    public string Phone { get; set; }
}
#pragma warning restore CS8618