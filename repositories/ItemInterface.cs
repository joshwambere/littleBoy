using LittleBoy.entities;

namespace LittleBoy.repositories;

public interface IItemInterface
{
 Item GetItem(Guid id);
 IEnumerable<Item> GetItems();
 void AddItem(Item item);
 void UpdateItem(Item item);
 void DeleteItem(Item item);
}
