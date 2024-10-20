    using MediatR;
using Microsoft.AspNetCore.Identity;
using Sazanowine.Application.Features.Users.Dto;
using Sazanowine.Domain.Constants;
using Sazanowine.Domain.Entities;

namespace Sazanowine.Application.Features.Users.Commands.Register;

public class RegisterCommandHandler
    (
        UserManager<User> userManager,
        IEmailService emailService
    ) : IRequestHandler<RegisterCommand, RegisterDto>
{
    public async Task<RegisterDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = request.RegisterMap();
        var result = await userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            return new RegisterDto
            {
                Succeeded = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }

        var emailToken = await userManager.GenerateEmailConfirmationTokenAsync(user);
        await emailService.SendVerificationEmailAsync(user.Email, emailToken);

        await userManager.AddToRoleAsync(user, UserRoles.User);

        return new RegisterDto
        {
            Succeeded = result.Succeeded,
            Errors = result.Errors.Select(e => e.Description)
        };
    }
}
