using Sazanowine.Domain.Entities;

namespace Sazanowine.Infrastructure.Repositories
{
    public interface IWineRepositorie
    {
        Task<IEnumerable<Wine>> GetAllAsync();
        Task<Wine?> GetByIdAsync(int id);
        Task<int> Create(Wine newWine);
        Task Delete(Wine wine);
        Task SaveChanges();
    }
}