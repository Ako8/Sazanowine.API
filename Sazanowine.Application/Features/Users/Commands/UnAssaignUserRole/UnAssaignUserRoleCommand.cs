using MediatR;

namespace Sazanowine.Application.Features.Users.Commands.UnAssaignUserRole;

public class UnAssaignUserRoleCommand : IRequest
{
    public string UserEmail { get; set; } = default!;
    public string RoleName { get; set; } = default!;
}
