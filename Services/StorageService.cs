using BlazorStorageSystem.Models.Order;
using BlazorStorageSystem.Models.Product;
using MongoDB.Driver;

namespace BlazorStorageSystem.Services;

public class StorageService
{
    public StorageService(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetConnectionString("MongoCloud"));
        var db = client.GetDatabase("storage_db");
        _products = db.GetCollection<Product>("products");
        _orders = db.GetCollection<Order>("orders");
    }

    private readonly IMongoCollection<Product> _products;
    private readonly IMongoCollection<Order> _orders;

    public async Task<List<Product>> GetProducts(string search = "", string category = "all")
    {
        return await _products
            .Find(x =>
                x.Name.ToLower().Contains(search.ToLower()) &&
                (category == "all" || x.Category == category)
            )
            .ToListAsync();
    }

    public async Task<List<Order>> GetOrders()
    {
        return await _orders.Find(_ => true).ToListAsync();
    }

    public async Task Delete(string id)
    {
        await _products.DeleteOneAsync(x => x.Id == id);
    }

    public async Task Update(Product product)
    {
        await _products.ReplaceOneAsync(Builders<Product>.Filter.Eq("Id", product.Id), product);
    }

    public async Task Save(Product product)
    {
        await _products.InsertOneAsync(product);
    }

    public async Task SaveOrder(Order order)
    {
        await _orders.InsertOneAsync(order);
    }
}