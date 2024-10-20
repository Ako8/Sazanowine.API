using Microsoft.AspNetCore.Identity;
using Sazanowine.Application.Services;
using Sazanowine.Domain.Constants;
using Sazanowine.Domain.Entities;
using ServiceStack;
using System.Security.Claims;
using System.Text.Json;

namespace Sazanowine.API.Middleware;

public class RoleBasedAuthorizationMiddleware(UserManager<User> _userManager, IJwtTokenService _jwtTokenService) : IMiddleware
{

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.User.Identity.IsAuthenticated)
        {
            var userId = context.User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(userId);

            if (user == null)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var tokenRoles = context.User.FindAll(ClaimTypes.Role).Select(c => c.Value);

            if (tokenRoles.Contains(UserRoles.Admin) && !userRoles.Contains(UserRoles.Admin))
            {
                // Roles have changed, generate a new token
                var newToken = _jwtTokenService.GenerateJwtToken(user, userRoles);
                context.Response.Headers.Add("NewToken", newToken);

                // Update the current ClaimsPrincipal with the new roles
                var identity = new ClaimsIdentity(context.User.Identity);
                identity.RemoveClaim(identity.FindFirst(ClaimTypes.Role));
                foreach (var role in userRoles)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, role));
                }
                context.User = new ClaimsPrincipal(identity);

                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                context.Response.ContentType = "application/json";

                var response = new
                {
                    message = "Your permissions have been updated. Please use the new token for subsequent requests.",
                    requiresReauthentication = true
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                return;
            }
        }

        await next(context);
    }
}