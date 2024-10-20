using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sazanowine.Domain.Constants;
using Sazanowine.Infrastructure.Persistence;

namespace Sazanowine.Infrastructure.Seeders;

internal class SazanowineSeeder(SazanowineDbContext dbContext) : ISazanowineSeeder
{
    public async Task Seed()
    {
        if (dbContext.Database.GetPendingMigrations().Any())
        {
            await dbContext.Database.MigrateAsync();
        }

        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Roles.Any())
            {
                var roles = GetRoles();
                dbContext.Roles.AddRange(roles);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<IdentityRole> GetRoles()
    {
        List<IdentityRole> roles =
            [
                 new (UserRoles.Admin){
                    NormalizedName =UserRoles.Admin.ToUpper(),
                },
                new (UserRoles.User){
                    NormalizedName =UserRoles.User.ToUpper(),
                }
            ];

        return roles;
    }
}
