#pragma warning disable CS8618
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorStorageSystem.Models.Product;

public class Product
{
    public Product()
    {
        
    }
    public Product(string id, string name, int count, string category, int? sale, int? sold, string? seller, string? manufacturer, DateTime expirationDate)
    {
        Id = id;
        Name = name;
        Count = count;
        Category = category;
        Sale = sale;
        Sold = sold;
        Seller = seller;
        Manufacturer = manufacturer;
        ExpirationDate = expirationDate;
    }
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

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