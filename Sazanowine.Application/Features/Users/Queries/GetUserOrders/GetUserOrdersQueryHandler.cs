using MediatR;
using Sazanowine.Application.Features.Orders.Dto;
using Sazanowine.Infrastructure.Repositories;

namespace Sazanowine.Application.Features.Users.Queries.GetUserOrders;

public class GetUserOrdersQueryHandler
    (
        IUserContext userContext,
        IOrderRepositorie orderRepositorie
    ) : IRequestHandler<GetUserOrdersQuery, IEnumerable<GetOrderForUserDto>>
{
    public async Task<IEnumerable<GetOrderForUserDto>> Handle(GetUserOrdersQuery request, CancellationToken cancellationToken)
    {
        var user = userContext.GetCurrentUser();

        var orders = await orderRepositorie.GetAllForUserAsync(user.Id);
        var result = orders.GetOrdersForUserHelper();
        return result;
    }
}
