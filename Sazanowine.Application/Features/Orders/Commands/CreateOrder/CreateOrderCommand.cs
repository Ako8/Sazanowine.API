using MediatR;
using Sazanowine.Application.Features.Orders.Dto;

namespace Sazanowine.Application.Features.Orders.Commands.CreateOrder;

public class CreateOrderCommand : IRequest<int>
{
    public string ZipCode{ get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Comment { get; set; }
    public List<CreateOrderDto> Items { get; set; } = [];
}
