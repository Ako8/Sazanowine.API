using Microsoft.EntityFrameworkCore;
using Sazanowine.Domain.Entities;
using Sazanowine.Infrastructure.Persistence;

namespace Sazanowine.Infrastructure.Repositories;

internal class OrderRepositorie(SazanowineDbContext dbContext) : IOrderRepositorie
{
    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        var orders = await dbContext.Orders
            .Include(o => o.Items)
                .ThenInclude(x => x.Wine)
                .AsNoTracking()
                .ToListAsync();
        return orders;
    }

    public async Task<IEnumerable<Order>> GetAllForUserAsync(string userId)
    {
        var orders = await dbContext.Orders
            .Where(o => o.CustomerId == userId)
            .Include(o => o.Items)
                .ThenInclude(x => x.Wine)
                .AsNoTracking()
                .ToListAsync();
        return orders;
    }

    public async Task<Order?> GetByIdAsync(int id)
    {
        var order = await dbContext.Orders
            .Include(o => o.Items)
                .ThenInclude(x => x.Wine)
                .SingleOrDefaultAsync(o => o.Id == id);

        return order;
    }

    public async Task<int> Create(Order newOrder)
    {
        dbContext.Orders.Add(newOrder);
        await dbContext.SaveChangesAsync();
        return newOrder.Id;
    }

    public async Task Delete(Order order)
    {
        dbContext.Remove(order);
        await dbContext.SaveChangesAsync();
    }
    public Task SaveChanges()
        => dbContext.SaveChangesAsync();


}
