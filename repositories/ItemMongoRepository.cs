using LittleBoy.entities;
using MongoDB.Driver;

namespace LittleBoy.repositories;

public class ItemMongoRepository : IItemInterface
{
    private  const string DatabaseName = "LittleBoy";
    private  const string CollectionName = "Items";
    private readonly IMongoCollection<Item> _itemsCollection;
    private readonly FilterDefinitionBuilder<Item> _filterBuilder = Builders<Item>.Filter;
    public ItemMongoRepository(IMongoClient mongoClient)
    {
        IMongoDatabase database = mongoClient.GetDatabase(DatabaseName);
        _itemsCollection = database.GetCollection<Item>(CollectionName);
    }
    
    public async void AddItem(Item item)
    {
        await _itemsCollection.InsertOneAsync(item);
    }
    public IEnumerable<Item> GetItems()
    {
        return _itemsCollection.Find(_=>true).ToList();
    }

    public Item GetItem(Guid id)
    {
        var filtered = _filterBuilder.Eq(item => item.Id, id);
        return _itemsCollection.Find(filtered).SingleOrDefault();
    }
    public async void DeleteItem(Item item)
    {
        
        await _itemsCollection.DeleteOneAsync(i => i.Id == item.Id);
    }
    public async void UpdateItem(Item item)
    {
        var filter = _filterBuilder.Eq(catalog => catalog.Id, item.Id);
        await _itemsCollection.ReplaceOneAsync(filter, item);
    }
    
}
