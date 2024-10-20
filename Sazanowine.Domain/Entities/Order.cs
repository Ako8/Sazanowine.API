using Sazanowine.Domain.Constants;

namespace Sazanowine.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public string CustomerId { get; set; } = string.Empty;
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public DateTime OrderSentDate { get; set; } 
    public string Status { get; set; } = OrderStatus.Pending;
    public string ZipCode { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Comment { get; set; }
    public List<OrderItem> Items { get; set; } = [];
}