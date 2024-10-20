using MediatR;
using Sazanowine.Application.Features.Users.Dto;

namespace Sazanowine.Application.Features.Users.Commands.Login;

public class LoginCommand : IRequest<LoginDto>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
