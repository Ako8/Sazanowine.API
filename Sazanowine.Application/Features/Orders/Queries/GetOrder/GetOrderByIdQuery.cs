using MediatR;
using Sazanowine.Application.Features.Orders.Dto;
using Sazanowine.Domain.Entities;

namespace Sazanowine.Application.Features.Orders.Queries.GetOrder;

public class GetOrderByIdQuery(int OrderId) : IRequest<GetOrderDto>
{
    public int Id { get; set; } = OrderId;
}
