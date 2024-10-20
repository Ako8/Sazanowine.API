using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Sazanowine.Domain.Entities;
using Sazanowine.Domain.Exceptions;

namespace Sazanowine.Application.Features.Users.Commands.VerifyEmail;

public class VerifyEmailCommandHandler(UserManager<User> userManager, IConfiguration configuration) : IRequestHandler<VerifyEmailCommand>
{
    public async Task Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user == null)
            throw new NotFoundException(nameof(User), request.Email);
        
        var result = await userManager.ConfirmEmailAsync(user, request.Token);
        if (!result.Succeeded)
            throw new Exception("Email Verification Failed");

        user.MailTokenExpireTime = null;
        await userManager.UpdateAsync(user);
    }
}
