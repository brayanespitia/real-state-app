using RealStateApp.Domain.Entities;

namespace RealStateApp.Domain.Repository
{
    public interface IPropertyImageRepository
    {
        Task<PropertyImage> GetByIdAsync(string id);
        Task<List<PropertyImage>> GetAllAsync();

        Task  AddAsync(PropertyImage propertyImage);

        Task <PropertyImage> GetFirstImageByPropertyIdAsync(string idProperty);

        Task<List<PropertyImage>> GetPropertysById(string idProperty);
    }
}
