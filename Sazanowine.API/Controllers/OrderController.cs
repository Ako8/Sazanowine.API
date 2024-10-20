using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sazanowine.Application.Features.Orders.Commands.CreateOrder;
using Sazanowine.Application.Features.Orders.Commands.DeleteOrder;
using Sazanowine.Application.Features.Orders.Commands.UpdateOrder;
using Sazanowine.Application.Features.Orders.Queries.GetOrder;
using Sazanowine.Application.Features.Orders.Queries.GetOrders;
using Sazanowine.Domain.Constants;

namespace Sazanowine.API.Controllers;


[ApiController]
[Route("api/orders")]
[Authorize]
public class OrderController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [Authorize(Roles = UserRoles.Admin)]
    public async Task<IActionResult> GetAllAsync()
    {
        var orders = await mediator.Send(new GetAllOrdersQuery());
        return Ok(orders);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderById(int id)
    {
        var order = await mediator.Send(new GetOrderByIdQuery(id));
        return Ok(order);
    }

    [HttpPost]
    [Authorize(Roles = UserRoles.User)]
    public async Task<IActionResult> AddOrder([FromBody] CreateOrderCommand command)
    {
        int id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetOrderById), new { id }, null);
    }

    [HttpPatch("{id}")]
    [Authorize(Roles = UserRoles.Admin)]
    public async Task<IActionResult> UpdateOrder([FromRoute] int id, UpdateOrderCommand command)
    {
        command.Id = id;
        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = UserRoles.User)]
    public async Task<IActionResult> DeleteOrder([FromRoute] int id)
    {
        await mediator.Send(new DeleteOrderCommand(id));
        return NoContent();
    }
}
