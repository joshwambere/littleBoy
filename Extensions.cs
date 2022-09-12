using littleBoy.Dtos;
using LittleBoy.entities;

namespace LittleBoy;

public static class Extensions
{
    public static ItemDto ToDto(this Item item)
    {
        return new ItemDto
        {
            Id = item.Id,
            name = item.name,
            price = item.price
        };
    }
}
