using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorStorageSystem.Models.Order;

public class Order
{
    public Order()
    {
        
    }

    public Order(string id, string name, DateTime date, List<ProductType> products, int price, string seller)
    {
        Id = id;
        Name = name;
        Date = date;
        Products = products;
        Price = price;
        Seller = seller;
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
    
    [BsonElement("products")]
    public List<ProductType> Products { get; set; }

    [BsonElement("price")]
    [BsonRepresentation(BsonType.Int32)]
    public int Price { get; set; }
    
    [BsonElement("seller")]
    [BsonRepresentation(BsonType.String)]
    public string Seller { get; set; }
    
    public class ProductType
    {
        [BsonElement("name")]
        [BsonRepresentation(BsonType.String)]
        public string Name { get; set; }
        [BsonElement("count")]
        [BsonRepresentation(BsonType.String)]
        public int Count { get; set; }
    }
}
