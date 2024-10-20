using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sazanowine.Application.Features.Rooms.Commands.CreateRoom;
using Sazanowine.Application.Features.Rooms.Commands.DeleteRoom;
using Sazanowine.Application.Features.Rooms.Commands.UpdateRoom;
using Sazanowine.Application.Features.Rooms.Queries.GetRoom;
using Sazanowine.Application.Features.Rooms.Queries.GetRooms;
using Sazanowine.Domain.Constants;

namespace Sazanowine.API.Controllers;

[ApiController]
[Route("api/rooms")]
public class RoomController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var rooms = await mediator.Send(new GetAllRoomsQuery());
        return Ok(rooms);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoomById([FromRoute] int id)
    {
        var room = await mediator.Send(new GetRoomByIdQuery(id));
        return Ok(room);
    }

    [HttpPost]
    [Authorize(Roles = UserRoles.Admin)]
    public async Task<IActionResult> AddRoom([FromBody] CreateRoomCommand command)
    {
        int id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetRoomById), new { id }, null);
    }

    [HttpPatch("{id}")]
    [Authorize(Roles = UserRoles.Admin)]
    public async Task<IActionResult> UpdateRoom([FromRoute] int id, UpdateRoomCommand command)
    {
        command.Id = id;
        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = UserRoles.Admin)]
    public async Task<IActionResult> DeleteRoom([FromRoute] int id)
    {
        await mediator.Send(new DeleteRoomCommand(id));
        return NoContent();
    }

    
}
