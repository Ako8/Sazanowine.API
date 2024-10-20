using MediatR;
using Microsoft.AspNetCore.Identity;
using Sazanowine.Domain.Entities;

namespace Sazanowine.Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler
    (
        UserManager<User> userManager,
        IUserContext userContext
    ) : IRequestHandler<DeleteUserCommand>
{
    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser();
        var user = await userManager.FindByIdAsync(currentUser.Id);
        await userManager.DeleteAsync(user);    
    }
}
