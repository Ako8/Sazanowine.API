using Sazanowine.Application.Features.Users.Dto;
using Sazanowine.Domain.Constants;

namespace Sazanowine.Application.Features.Orders.Dto;

public class GetOrderDto
{
    public int Id { get; set; }
    public UserDto Customer { get; set; }
    public string ZipCode { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Comment { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public string Status { get; set; } = OrderStatus.Pending;
    public decimal OrderPrice { get; set; }
    public List<OrderItemDto> Items { get; set; } = [];
}
