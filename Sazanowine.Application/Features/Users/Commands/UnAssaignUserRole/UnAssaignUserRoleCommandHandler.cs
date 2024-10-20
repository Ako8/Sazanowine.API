using MediatR;
using Microsoft.AspNetCore.Identity;
using Sazanowine.Domain.Entities;
using Sazanowine.Domain.Exceptions;

namespace Sazanowine.Application.Features.Users.Commands.UnAssaignUserRole;

public class UnAssaignUserRoleCommandHandler
    (
        UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager
    ) : IRequestHandler<UnAssaignUserRoleCommand>
{
    public async Task Handle(UnAssaignUserRoleCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.UserEmail)
            ?? throw new NotFoundException(nameof(User), request.UserEmail);

        var role = await roleManager.FindByNameAsync(request.RoleName)
            ?? throw new NotFoundException(nameof(IdentityRole), request.RoleName);

        await userManager.RemoveFromRoleAsync(user, role.Name!);
    }
}
