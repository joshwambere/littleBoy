namespace LittleBoy.entities
{
 public record Item
 {
  public Guid Id { get; init; }
  public string? name { get; init; }
  public decimal price { get; init; }
  public DateTimeOffset createdAt { get; init; }

 }
}
