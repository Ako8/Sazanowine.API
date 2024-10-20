using MediatR;
using Sazanowine.Application.Features.Orders.Dto;

namespace Sazanowine.Application.Features.Orders.Queries.GetOrders;

public class GetAllOrdersQuery : IRequest<IEnumerable<GetOrderDto>>
{
}
