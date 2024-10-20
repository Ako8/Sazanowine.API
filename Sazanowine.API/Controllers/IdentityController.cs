using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sazanowine.Application.Features.Users.Commands.AssaignUserRole;
using Sazanowine.Application.Features.Users.Commands.DeleteUser;
using Sazanowine.Application.Features.Users.Commands.Login;
using Sazanowine.Application.Features.Users.Commands.Register;
using Sazanowine.Application.Features.Users.Commands.UnAssaignUserRole;
using Sazanowine.Application.Features.Users.Commands.UpdateUser;
using Sazanowine.Application.Features.Users.Commands.VerifyEmail;
using Sazanowine.Application.Features.Users.Queries.GetAllUsers;
using Sazanowine.Application.Features.Users.Queries.GetUserOrders;
using Sazanowine.Domain.Constants;

namespace Sazanowine.API.Controllers;

[ApiController]
[Route("api/identity")]
public class IdentityController
    (
        IMediator mediator,
        IConfiguration configuration
    ) : ControllerBase
{
    [HttpGet("users")]
    [Authorize(Roles = UserRoles.Admin)]
    public async Task<IActionResult> GetAllUserAsync()
    {
        var users = await mediator.Send(new GetAllUsersQuery());
        return Ok(users);
    }

    [HttpPatch("updateUser")]
    [Authorize(Roles = UserRoles.User)]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("deleteUser")]
    [Authorize(Roles = UserRoles.User)]
    public async Task<IActionResult> DeleteUser()
    {
        await mediator.Send(new DeleteUserCommand());
        return NoContent();
    }


    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterCommand command)
    {
        var result = await mediator.Send(command);
        if(result.Succeeded)
            return Ok(new { Message = "User registered successfully" });
        return BadRequest( new { Errors = result.Errors });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand command)
    {
        var result = await mediator.Send(command);
        if (result.Succeeded)
            return Ok(new { Token = result.Token, Message = "Login successful" });
        return Unauthorized(new { Message = "Invalid username or password" });
    }

    [HttpPost("userRole")]
    [Authorize(Roles = UserRoles.Admin)]
    public async Task<IActionResult> AssaignUserRole(AssaignUserRoleCommand command)
    {
        User.Claims.ToArray();
        await mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("userRole")]
    [Authorize(Roles = UserRoles.Admin)]
    public async Task<IActionResult> UnAssaignUserRole(UnAssaignUserRoleCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }

    [HttpGet("userOrders")]
    [Authorize(Roles = UserRoles.User)]
    public async Task<IActionResult> GetUserOrders()
    {
        var orders = await mediator.Send(new GetUserOrdersQuery());
        return Ok(orders);
    }

    [HttpGet("verifyEmail")]
    public async Task<IActionResult> VerifyEmail([FromQuery] string token, [FromQuery] string email)     
    {
        var command = new VerifyEmailCommand { Token = token, Email = email };
        await mediator.Send(command);
        return new RedirectResult($"{configuration["ClientAppUrl"]}");
    }
}
