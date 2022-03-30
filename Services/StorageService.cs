using BlazorStorageSystem.Models.Category;
using BlazorStorageSystem.Models.Order;
using BlazorStorageSystem.Models.Product;
using BlazorStorageSystem.Models.Sellers;
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
        _sellers = db.GetCollection<Seller>("sellers");
        _category = db.GetCollection<Category>("categories");
    }

    private readonly IMongoCollection<Product> _products;
    private readonly IMongoCollection<Order> _orders;
    private readonly IMongoCollection<Seller> _sellers;
    private readonly IMongoCollection<Category> _category;

    public async Task<List<Product>> GetProducts(string search = "", string category = "all")
    {
        return await _products
            .Find(x =>
                x.Name.ToLower().Contains(search.ToLower()) &&
                (category == "all" || x.Category == category)
            )
            .ToListAsync();
    }

    public async Task<List<Seller>> GetSellers()
    {
        return await _sellers.Find(x => true).ToListAsync();
    }

    public async Task<List<Order>> GetOrders()
    {
        return await _orders.Find(_ => true).ToListAsync();
    }
    
    public async Task<List<Category>> GetCategories()
    {
        return await _category.Find(_ => true).ToListAsync();
    }

    public async Task Delete(string id)
    {
        await _products.DeleteOneAsync(x => x.Id == id);
    }
    
    public async Task DeleteSeller(string id)
    {
        await _sellers.DeleteOneAsync(x => x.Id == id);
    }
    
    public async Task DeleteCategory(string id)
    {
        await _category.DeleteOneAsync(x => x.Id == id);
    }
    
    public async Task DeleteOrder(string id)
    {
        await _orders.DeleteOneAsync(x => x.Id == id);
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
    
    public async Task SaveSeller(Seller seller)
    {
        await _sellers.InsertOneAsync(seller);
    }
    
    public async Task SaveCategory(Category category)
    {
        await _category.InsertOneAsync(category);
    }
    
}