namespace Sazanowine.Domain.Entities;

public class OrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int WineId { get; set; }
    public Wine Wine { get; set; }
    public int Quantity { get; set; }
    public decimal PriceAtOrder { get; set; }
}
