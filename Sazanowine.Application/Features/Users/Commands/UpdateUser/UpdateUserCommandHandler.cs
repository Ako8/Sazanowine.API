using MediatR;
using Microsoft.AspNetCore.Identity;
using Sazanowine.Domain.Entities;

namespace Sazanowine.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler
    (
        UserManager<User> userManager,
        IUserContext userContext
    ) : IRequestHandler<UpdateUserCommand>
{
    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser();
        var user = await userManager.FindByIdAsync(currentUser.Id);

        user.UserName = request.Email;
        user.FirstName = request.Name;
        user.LastName = request.SurName;
        user.Email = request.Email;
        user.PhoneNumber = request.PhoneNumber;
        user.NormalizedEmail = request.Email.ToUpper();
        user.NormalizedUserName = request.Email.ToUpper();


        await userManager.UpdateAsync(user);
    }
}
