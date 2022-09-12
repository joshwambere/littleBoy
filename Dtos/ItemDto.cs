namespace littleBoy.Dtos;


public record ItemDto
{
    public Guid Id { get; init; }
    public string? name { get; init; }
    public decimal price { get; init; }

}
