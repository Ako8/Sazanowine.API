using Microsoft.EntityFrameworkCore;
using Sazanowine.Domain.Entities;
using Sazanowine.Infrastructure.Persistence;

namespace Sazanowine.Infrastructure.Repositories;

internal class RoomRepositorie(SazanowineDbContext dbContext) : IRoomRepositorie
{
    public async Task<IEnumerable<Room>> GetAllAsync()
    {
        var rooms = await dbContext.Rooms
            .Include(r => r.Description)
            .AsNoTracking()
            .ToListAsync();
        return rooms;
    }

    public async Task<Room?> GetByIdAsync(int id)
    {
        var room = await dbContext.Rooms
            .Include(r => r.Description)
            .SingleOrDefaultAsync(r => r.Id == id);
        return room;
    }

    public async Task<int> Create(Room newRoom)
    {
        dbContext.Rooms.Add(newRoom);
        await dbContext.SaveChangesAsync();
        return newRoom.Id;
    }

    public async Task Delete(Room room)
    {
        dbContext.Rooms.Remove(room);
        await dbContext.SaveChangesAsync();
    }
    public Task SaveChanges()
        => dbContext.SaveChangesAsync();
}
