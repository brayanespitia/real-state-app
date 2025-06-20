using RealStateApp.Application.Dto;
using RealStateApp.Domain.Entities;
using System.Threading.Tasks;

namespace RealStateApp.Application.Interfaces
{
    public interface IPropertyService
    {
        Task<List<PropertyDto>> GetAllAsync();
        Task<Property> GetByIdAsync(string id);
        Task <PropertyDto> AddAsync(PropertyDto property);
        Task UpdateAsync(Property property);
        Task DeleteAsync(string id);

        

    }
}
