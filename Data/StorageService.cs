using MongoDB.Driver;

namespace BlazorStorageSystem.Data;

public class StorageService
{
    public StorageService(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetConnectionString("MongoCloud"));
        var db = client.GetDatabase("storage_db");
        _products = db.GetCollection<Product>("products");
    }

    private readonly IMongoCollection<Product> _products;

    public async Task<List<Product>> GetProducts(string search = "")
    {
        return await _products.Find(x => x.Name.ToLower().Contains(search.ToLower())).ToListAsync();
    }
}
