namespace littleBoy.Dtos;

public record CreateItemDto
{
    public string name { get; init; }
    public decimal price { get; init; }
    
};
