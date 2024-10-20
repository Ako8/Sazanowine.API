using MediatR;
using Sazanowine.Application.Features.Orders.Dto;
using Sazanowine.Domain.Entities;
using Sazanowine.Domain.Exceptions;
using Sazanowine.Infrastructure.Repositories;

namespace Sazanowine.Application.Features.Orders.Commands.UpdateOrder;

public class UpdateOrderCommandHandler
    (
        IOrderRepositorie orderRepositorie
    ) : IRequestHandler<UpdateOrderCommand>
{
    public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await orderRepositorie.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(Order), request.Id.ToString());

        request.Map(order);

        await orderRepositorie.SaveChanges();
    }
}
