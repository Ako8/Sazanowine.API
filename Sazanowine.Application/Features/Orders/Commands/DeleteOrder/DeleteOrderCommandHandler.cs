using MediatR;
using Sazanowine.Domain.Entities;
using Sazanowine.Domain.Exceptions;
using Sazanowine.Infrastructure.Repositories;

namespace Sazanowine.Application.Features.Orders.Commands.DeleteOrder;

public class DeleteOrderCommandHandler
    (
        IOrderRepositorie orderRepositorie
    ) : IRequestHandler<DeleteOrderCommand>
{
    public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await orderRepositorie.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(Order), request.Id.ToString());

        await orderRepositorie.Delete(order);
    }
}
