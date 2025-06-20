using RealStateApp.Application.Dto;
using RealStateApp.Domain.Entities;

namespace RealStateApp.Application.Interfaces
{
    public interface IPropertyImageService
    {
        Task<PropertyImageDto> GetByIdAsync(string id);
        Task<List<PropertyImageDto>> GetAllAsync();
        Task <PropertyImageDto> AddAsync(PropertyImageDto propertyImage);

        Task<List<PropertyImageDto>> GetByPropertyIdAsync(string propertyId);
    }
}
