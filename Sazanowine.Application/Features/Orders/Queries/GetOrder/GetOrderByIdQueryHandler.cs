using MediatR;
using Sazanowine.Application.Features.Orders.Dto;
using Sazanowine.Application.Features.Users;
using Sazanowine.Domain.Entities;
using Sazanowine.Domain.Exceptions;
using Sazanowine.Infrastructure.Repositories;

namespace Sazanowine.Application.Features.Orders.Queries.GetOrder;

public class GetOrderByIdQueryHandler
    (
        IOrderRepositorie orderRepositorie
    ) : IRequestHandler<GetOrderByIdQuery, GetOrderDto>
{
    public async Task<GetOrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {

        var order = await orderRepositorie.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(Order), request.Id.ToString());

        var result = order.ToDto();

        return result;
    }
}
