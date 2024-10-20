using MediatR;

namespace Sazanowine.Application.Features.Orders.Commands.DeleteOrder;

public class DeleteOrderCommand(int OrderId) : IRequest
{
    public int Id { get; set; } = OrderId;
}
