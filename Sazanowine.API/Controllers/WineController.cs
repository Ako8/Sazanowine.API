using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sazanowine.Application.Features.Wines.Commands.CreateWine;
using Sazanowine.Application.Features.Wines.Commands.DeleteWine;
using Sazanowine.Application.Features.Wines.Commands.UpdateWine;
using Sazanowine.Application.Features.Wines.Queries.GetWine;
using Sazanowine.Application.Features.Wines.Queries.GetWines;
using Sazanowine.Domain.Constants;

namespace Sazanowine.API.Controllers;

[ApiController]
[Route("api/wines/")]
public class WineController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllWine()
    {
        var wines = await mediator.Send(new GetWinesQuery());
        return Ok(wines);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetWineById([FromRoute] int id)
    {
        var wine = await mediator.Send(new GetWineQuery(id));
        return Ok(wine);
    }

    [HttpPost]
    [Authorize(Roles = UserRoles.Admin)]
    public async Task<IActionResult> AddWine([FromBody] CreateWineCommand command)
    {
        int id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetWineById), new { id }, null);
    }

    [HttpPatch("{id}")]
    [Authorize(Roles = UserRoles.Admin)]
    public async Task<IActionResult> UpdateWine([FromRoute] int id, UpdateWineCommand command)
    {
        command.Id = id;
        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = UserRoles.Admin)]
    public async Task<IActionResult> DeleteWine([FromRoute] int id)
    {
        await mediator.Send(new DeleteWineCommand(id));
        return NoContent();
    }
}
