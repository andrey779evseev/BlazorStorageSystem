using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorStorageSystem.Models.Order;

public class Order
{
    public Order()
    {
        
    }

    public Order(string id, string name, DateTime date, string productName, int count, int price)
    {
        Id = id;
        Name = name;
        Date = date;
        ProductName = productName;
        Count = count;
        Price = price;
    }

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    
    [BsonElement("name")]
    [BsonRepresentation(BsonType.String)]
    public string Name { get; set; }
    
    [BsonElement("date")]
    [BsonRepresentation(BsonType.DateTime)]
    public DateTime Date { get; set; }
    
    [BsonElement("product_name")]
    [BsonRepresentation(BsonType.String)]
    public string ProductName { get; set; }
    
    [BsonElement("count")]
    [BsonRepresentation(BsonType.Int32)]
    public int Count { get; set; }
    
    [BsonElement("price")]
    [BsonRepresentation(BsonType.Int32)]
    public int Price { get; set; }
}