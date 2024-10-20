using Sazanowine.Domain.Entities;

namespace Sazanowine.Infrastructure.Repositories
{
    public interface IRoomRepositorie
    {
        Task<IEnumerable<Room>> GetAllAsync();
        Task<Room?> GetByIdAsync(int id);
        Task<int> Create(Room newRoom);
        Task Delete(Room room);
        Task SaveChanges();
    }
}