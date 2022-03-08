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
    }

    private readonly IMongoCollection<Product> _products;

    public async Task<List<Product>> GetProducts(string search = "", string category = "all")
    {
        return await _products
            .Find(x =>
                x.Name.ToLower().Contains(search.ToLower()) &&
                (category == "all" || x.Category == category)
            )
            .ToListAsync();
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
}