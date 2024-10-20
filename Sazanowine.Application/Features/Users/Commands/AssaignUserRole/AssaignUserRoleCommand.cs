using MediatR;

namespace Sazanowine.Application.Features.Users.Commands.AssaignUserRole;

public class AssaignUserRoleCommand : IRequest
{
    public string UserEmail { get; set; } = default!;
    public string RoleName { get; set; } = default!;
}
