using littleBoy.Dtos;
using LittleBoy.entities;
using LittleBoy.repositories;
using Microsoft.AspNetCore.Mvc;

namespace LittleBoy.Controllers
{
  [ApiController]
  [Route("/api/[controller]")]
  public class ItemsController : ControllerBase
  {
    private readonly IItemInterface _itemRepository;
    public ItemsController(IItemInterface itemRepository)
    {
      _itemRepository = itemRepository;
    }
    [HttpGet]
    public IEnumerable<ItemDto> GetAllItems()
    {
      return _itemRepository.GetItems().Select(item=>  Extensions.ToDto(item));
    }
    
    [HttpGet("{id}")]
    public ActionResult<ItemDto> GetItemById(Guid id)
    {
      var catalog = _itemRepository.GetItem(id);
      if (catalog == null)
      {
        return NotFound();
      }

      return catalog.ToDto();
    }
    
    [HttpPost]
    public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
    {
      Item item = new() {
        Id= Guid.NewGuid(),
        name= itemDto.name,
        price= itemDto.price,
        createdAt= DateTimeOffset.UtcNow,
      };
      _itemRepository.AddItem(item);
      return CreatedAtAction(nameof(GetItemById), new { id = item.Id }, item.ToDto());
    }
    [HttpPut("{id}")]
    public ActionResult UpdateItem(Guid id, UpdateDto itemDto)
    {
      var item = _itemRepository.GetItem(id);
      if (item == null) 
      {
        return NotFound();
      }

      Item updatedItem = item with
      {
        name = itemDto.name,
        price = itemDto.price
      };
        _itemRepository.UpdateItem(updatedItem);
      return NoContent();
    }
    [HttpDelete("{id}")]
    public  ActionResult DeleteItem(Guid id)
    {
      var item = _itemRepository.GetItem(id);
      if (item == null)
      {
        return NotFound();
      }
      _itemRepository.DeleteItem(item);
      return NoContent();
    }
  }
}
