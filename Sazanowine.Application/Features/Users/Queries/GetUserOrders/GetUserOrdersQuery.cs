using MediatR;
using Sazanowine.Application.Features.Orders.Dto;

namespace Sazanowine.Application.Features.Users.Queries.GetUserOrders;

public class GetUserOrdersQuery : IRequest<IEnumerable<GetOrderForUserDto>>
{
}
