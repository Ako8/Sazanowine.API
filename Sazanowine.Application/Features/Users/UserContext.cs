using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Sazanowine.Application.Features.Users;

public interface IUserContext
{
    CurrentUser? GetCurrentUser();
}

public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    public CurrentUser? GetCurrentUser()
    {
        var user = (httpContextAccessor?.HttpContext?.User);
       
        if (user == null)
            throw new InvalidOperationException("User context is not present");

        if (user.Identity == null || !user.Identity.IsAuthenticated)
            throw new Exception("User not authenticated");

        var userId = user.FindFirst(c => c.Type == "id")!.Value;
        var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role)!.Select(c => c.Value);
        var email = user.FindFirst(c => c.Type == ClaimTypes.Email)!.Value;


        if (userId == null || email == null)
            throw new Exception("User claims are incomplete");

        return new CurrentUser(userId, email, roles);
    }


}
