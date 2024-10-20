using MediatR;

namespace Sazanowine.Application.Features.Orders.Commands.UpdateOrder;

public class UpdateOrderCommand : IRequest
{
    public int Id { get; set; }
    public string Status { get; set; }
}
