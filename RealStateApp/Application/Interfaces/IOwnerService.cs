using RealStateApp.Application.Dto;
using RealStateApp.Domain.Entities;

namespace RealStateApp.Application.Interfaces
{
    public interface IOwnerService
    {
        Task<List<OwnerDto>> GetAllAsync();
        Task<Owner> GetByIdAsync(string id);
        Task <OwnerDto> AddAsync(OwnerDto owner);
        Task UpdateAsync(Owner owner);
        Task DeleteAsync(string id);
    }
}
