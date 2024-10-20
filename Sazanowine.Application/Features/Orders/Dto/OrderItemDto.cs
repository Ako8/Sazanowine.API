using Sazanowine.Domain.Entities;

namespace Sazanowine.Application.Features.Orders.Dto;

public class OrderItemDto
{
    public int ItemId { get; set; }
    public Wine Wine { get; set; }
    public int Quantity { get; set; }
    public decimal PriceAtOrder { get; set; }
}
