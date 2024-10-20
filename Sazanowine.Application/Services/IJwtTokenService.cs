using Sazanowine.Domain.Entities;

namespace Sazanowine.Application.Services
{
    public interface IJwtTokenService
    {
        string GenerateJwtToken(User? user, IList<string> userRoles);
    }
}