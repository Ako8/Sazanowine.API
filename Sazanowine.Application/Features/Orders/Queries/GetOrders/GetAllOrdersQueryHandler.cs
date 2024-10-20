using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sazanowine.Application.Features.Orders.Dto;
using Sazanowine.Application.Features.Users;
using Sazanowine.Domain.Entities;
using Sazanowine.Infrastructure.Repositories;

namespace Sazanowine.Application.Features.Orders.Queries.GetOrders;

public class GetAllOrdersQueryHandler
    (
        IOrderRepositorie orderRepositorie,
        IUserContext userContext, 
        UserManager<User> userManager
    ) : IRequestHandler<GetAllOrdersQuery, IEnumerable<GetOrderDto>>
{
    public async Task<IEnumerable<GetOrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser();
        var orders = await orderRepositorie.GetAllAsync();

        var userIds = orders.Select(o => o.CustomerId).Distinct().ToList();
        var users = await userManager.Users
            .Where(u => userIds.Contains(u.Id))
            .ToDictionaryAsync(u => u.Id, cancellationToken);

        var result = orders.GetAllOrdersHelper(users);
        return result;
    }
}
