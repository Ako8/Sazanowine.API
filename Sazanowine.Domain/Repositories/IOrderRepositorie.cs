using Sazanowine.Domain.Entities;

namespace Sazanowine.Infrastructure.Repositories
{
    public interface IOrderRepositorie
    {
        Task<int> Create(Order newOrder);
        Task Delete(Order room);
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(int id);
        Task SaveChanges();
        Task<IEnumerable<Order>> GetAllForUserAsync(string userId);
    }
}