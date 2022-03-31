#pragma warning disable CS8618
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorStorageSystem.Models.Product;

public class Product
{
    public Product() { }
    public Product(string id, string name, int count, string category, int? sold, string? manufacturer, DateTime expirationDate, DateTime created, int price)
    {
        Id = id;
        Name = name;
        Count = count;
        Category = category;
        Sold = sold;
        Manufacturer = manufacturer;
        ExpirationDate = expirationDate;
        Created = created;
        Price = price;
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

    [BsonElement("sold")]
    [BsonRepresentation(BsonType.Int32)]
    public int? Sold { get; set; }

    [BsonElement("manufacturer")]
    [BsonRepresentation(BsonType.String)]
    public string? Manufacturer { get; set; }

    [BsonElement("expiration_date")]
    [BsonRepresentation(BsonType.DateTime)]
    public DateTime ExpirationDate { get; set; }
    [BsonElement("created")]
    [BsonRepresentation(BsonType.DateTime)]
    public DateTime Created { get; set; }
    [BsonElement("price")]
    [BsonRepresentation(BsonType.Int32)]
    public int Price { get; set; }
}
#pragma warning restore CS8618