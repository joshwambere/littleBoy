using LittleBoy.entities;

namespace LittleBoy.repositories
{
 public class ItemRepository : IItemInterface
 {
  private readonly List<Item> _items = new()
   {
     new Item {Id = Guid.NewGuid(),name = "game of thrones", price=23, createdAt=DateTimeOffset.UtcNow},
     new Item {Id = Guid.NewGuid(),name = "young sheldon", price=13, createdAt=DateTimeOffset.UtcNow},
     new Item {Id = Guid.NewGuid(),name = "Madiba", price=23, createdAt=DateTimeOffset.UtcNow} 

   };

  public IEnumerable<Item> GetItems()
  {
   return _items;
  }
  public Item GetItem(Guid id)
  {
   return _items.Where(x => x.Id == id).SingleOrDefault();
  }
  public void AddItem(Item item)
  {
   _items.Add(item);
  }
  public void UpdateItem(Item item)
  {
   var index = _items.FindIndex(x => x.Id == item.Id);
   _items[index] = item;
   
  }
  public void DeleteItem(Item item)
  {
   _items.Remove(item);
  }

 }

}
