using MediatR;
using Microsoft.AspNetCore.Identity;
using Sazanowine.Application.Features.Users.Dto;
using Sazanowine.Application.Services;
using Sazanowine.Domain.Entities;
using Sazanowine.Domain.Exceptions;


namespace Sazanowine.Application.Features.Users.Commands.Login;

public class LoginCommandHandler
    (
        UserManager<User> userManager,
        IJwtTokenService jwtTokenService,
        SignInManager<User> signInManager
    ) : IRequestHandler<LoginCommand, LoginDto>
{
    public async Task<LoginDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email);
        if ( user == null ) 
            throw new NotFoundException(nameof(User), request.Email);

        if (!user.EmailConfirmed)
            throw new Exception("Please verify your email before logging in.");
        
        var result = await signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: false);
        if (!result.Succeeded)
            throw new Exception("Invalid email or password.");
        

        var userRoles = await userManager.GetRolesAsync( user );
        var token = jwtTokenService.GenerateJwtToken(user, userRoles);

        return new LoginDto
        {
            Succeeded = true,
            Token = token,
        };
    }
}
