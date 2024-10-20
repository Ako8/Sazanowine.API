using Microsoft.EntityFrameworkCore;
using Sazanowine.Domain.Entities;
using Sazanowine.Infrastructure.Persistence;

namespace Sazanowine.Infrastructure.Repositories;

internal class WineRepositorie(SazanowineDbContext dbContext) : IWineRepositorie
{
    public async Task<IEnumerable<Wine>> GetAllAsync()
    {
        var wines = await dbContext.Wines.AsNoTracking().ToListAsync();
        return wines;
    }

    public async Task<Wine?> GetByIdAsync(int id)
    {
        var wine = await dbContext.Wines.SingleOrDefaultAsync(r => r.Id == id);
        return wine;
    }

    public async Task<int> Create(Wine newWine)
    {
        dbContext.Wines.Add(newWine);
        await dbContext.SaveChangesAsync();
        return newWine.Id;
    }

    public async Task Delete(Wine wine)
    {
        dbContext.Wines.Remove(wine);
        await dbContext.SaveChangesAsync();
    }
    public Task SaveChanges()
        => dbContext.SaveChangesAsync();
}
