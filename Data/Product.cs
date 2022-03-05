#pragma warning disable CS8618
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorStorageSystem.Data;

public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    [BsonElement("name")]
    [BsonRepresentation(BsonType.String)]
    public string Name { get; set; }
    [BsonElement("count")]
    [BsonRepresentation(BsonType.Int32)]
    public int Count { get; set; }
    
    [BsonElement("category")]
    [BsonRepresentation(BsonType.String)]
    public string Category { get; set; }
    
    [BsonElement("sale")]
    [BsonRepresentation(BsonType.Int32)]
    public int? Sale { get; set; }
    
    [BsonElement("sold")]
    [BsonRepresentation(BsonType.Int32)]
    public int? Sold { get; set; }
    
    [BsonElement("seller")]
    [BsonRepresentation(BsonType.String)]
    public string? Seller { get; set; }
    
    [BsonElement("manufacturer")]
    [BsonRepresentation(BsonType.String)]
    public string? Manufacturer { get; set; }
    
    [BsonElement("expiration_date")]
    [BsonRepresentation(BsonType.DateTime)]
    public DateTime ExpirationDate { get; set; }
}
#pragma warning restore CS8618
