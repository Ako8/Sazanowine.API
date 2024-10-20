using MediatR;
using Sazanowine.Application.Features.Orders.Dto;
using Sazanowine.Application.Features.Users;
using Sazanowine.Domain.Entities;
using Sazanowine.Domain.Exceptions;
using Sazanowine.Infrastructure.Repositories;

namespace Sazanowine.Application.Features.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler
    (
        IOrderRepositorie orderRepositorie,
        IUserContext userContext,
        IWineRepositorie wineRepositorie
    ) : IRequestHandler<CreateOrderCommand, int>
{
    public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var user = userContext.GetCurrentUser();
        
        var newOrder = request.ToEntity();

        foreach (var item in newOrder.Items) 
        {
            var wine = await wineRepositorie.GetByIdAsync(item.WineId)
                ?? throw new NotFoundException(nameof(Wine), item.WineId.ToString());

            if (item.Quantity > wine.StockQuantity)
                throw new Exception("Not Enough Wine in Stock");

            item.PriceAtOrder = wine.Price;
            wine.StockQuantity -= item.Quantity;
        }

        newOrder.CustomerId = user.Id;

        var orderId = await orderRepositorie.Create(newOrder);

        return orderId;

    }
}
