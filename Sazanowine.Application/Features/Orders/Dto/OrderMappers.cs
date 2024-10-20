using Sazanowine.Application.Features.Orders.Commands.CreateOrder;
using Sazanowine.Application.Features.Orders.Commands.UpdateOrder;
using Sazanowine.Application.Features.Users.Dto;
using Sazanowine.Domain.Constants;
using Sazanowine.Domain.Entities;

namespace Sazanowine.Application.Features.Orders.Dto;

public static class OrderMappers
{
    public static Order ToEntity(this CreateOrderCommand command)
    {
        var newOrder = new Order()
        {
            OrderDate = DateTime.UtcNow,
            Status = OrderStatus.Pending,
            ZipCode = command.ZipCode,
            Address = command.Address,
            City = command.City,
            Comment = command.Comment,
            Items = command.Items.Select(item => new OrderItem()
            {
                WineId = item.WineId,
                Quantity = item.Quantity,
            }).ToList(),
        };

        return newOrder;
    }

    public static Order Map(this UpdateOrderCommand command, Order order)
    {
        if (OrderStatus.Statuses.Contains(command.Status))
            order.Status = command.Status;
        else throw new Exception($"Order status '{command.Status}' does't exists");

        if (order.Status == OrderStatus.Sent)
            order.OrderSentDate = DateTime.UtcNow;

        return order;
    }

    public static GetOrderDto ToDto(this Order order)
    {
        return new GetOrderDto()
        {
            Id = order.Id,
            OrderDate = order.OrderDate,
            Status = order.Status,
            ZipCode = order.ZipCode,
            City = order.City,
            Address = order.Address,
            Comment = order.Comment,
            OrderPrice = order.Items.Select(x => x.Quantity * x.PriceAtOrder).Sum(),
            Items = order.Items.Select(item => new OrderItemDto()
            {
                ItemId = item.Id,
                Wine = item.Wine,
                Quantity = item.Quantity,
                PriceAtOrder = item.PriceAtOrder,
            }).ToList()
        };
    }


    public static IEnumerable<GetOrderDto> GetAllOrdersHelper(this IEnumerable<Order>? orders, Dictionary<string, User> users)
    {
        return orders.Select(ord => new GetOrderDto()
        {
            Id = ord.Id,
            Customer = users.TryGetValue(ord.CustomerId, out var user) ? user.ToDto() : null,
            ZipCode = ord.ZipCode,
            Address = ord.Address,
            Comment = ord.Comment,
            City = ord.City,
            OrderDate = ord.OrderDate,
            Status = ord.Status,
            OrderPrice = ord.Items.Select(x => x.Quantity * x.PriceAtOrder).Sum(),
            Items = ord.Items.Select(item => new OrderItemDto()
            {
                ItemId = item.Id,
                Wine = item.Wine,
                Quantity = item.Quantity,
                PriceAtOrder = item.PriceAtOrder,
            }).ToList()
        });
    }

    public static IEnumerable<GetOrderForUserDto> GetOrdersForUserHelper(this IEnumerable<Order>? orders)
    {
        return orders.Select(ord => new GetOrderForUserDto()
        {
            Id = ord.Id,
            ZipCode = ord.ZipCode,
            Address = ord.Address,
            City = ord.City,
            OrderDate = ord.OrderDate,
            Status = ord.Status,
            OrderPrice = ord.Items.Select(x => x.Quantity * x.PriceAtOrder).Sum(),
            Items = ord.Items.Select(item => new OrderItemDto()
            {
                ItemId = item.Id,
                Wine = item.Wine,
                Quantity = item.Quantity,
                PriceAtOrder = item.PriceAtOrder,
            }).ToList()
        });
    }
}
