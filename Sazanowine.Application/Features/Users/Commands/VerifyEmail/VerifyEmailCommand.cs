using MediatR;

namespace Sazanowine.Application.Features.Users.Commands.VerifyEmail;

public class VerifyEmailCommand : IRequest
{
    public string Email { get; set; }
    public string Token { get; set; }
}
