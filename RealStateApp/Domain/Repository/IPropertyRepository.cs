using RealStateApp.Domain.Entities;

namespace RealStateApp.Domain.Repository
{
    public interface IPropertyRepository
    {
        Task<List<Property>> GetAllAsync();
        Task<Property> GetByIdAsync(string id);
        Task AddAsync(Property property);
        Task UpdateAsync(Property property);
        Task DeleteAsync(string id);
    }
}
