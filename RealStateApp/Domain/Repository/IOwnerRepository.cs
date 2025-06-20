using RealStateApp.Domain.Entities;

namespace RealStateApp.Domain.Repository
{
    public interface IOwnerRepository
    {
        Task<List<Owner>> GetAllAsync();
        Task<Owner> GetByIdAsync(string id);
        Task AddAsync(Owner owner);
        Task UpdateAsync(Owner owner);
        Task DeleteAsync(string id);
    }
}
