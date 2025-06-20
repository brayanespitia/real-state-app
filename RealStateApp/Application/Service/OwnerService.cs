using AutoMapper;
using MongoDB.Bson;
using RealStateApp.Application.Dto;
using RealStateApp.Application.Interfaces;
using RealStateApp.Domain.Entities;
using RealStateApp.Domain.Repository;

namespace RealStateApp.Application.Service
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _repository;

        private readonly IMapper _mapper;

        public OwnerService(IOwnerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task <OwnerDto> AddAsync(OwnerDto dto)
        {
            try
            {
                var owner = _mapper.Map<Owner>(dto);
                await _repository.AddAsync(owner);

                // Mapear de vuelta el Owner con ID generado al DTO
                var resultDto = _mapper.Map<OwnerDto>(owner);
                return resultDto;

            }
            catch (Exception e)
            {

                throw e;
            }            
            

        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OwnerDto>> GetAllAsync()
        {
            try
            {
                var owners = await _repository.GetAllAsync();                
                if (!owners.Any())
                    return new List<OwnerDto>();

                return _mapper.Map<List<OwnerDto>>(owners);
            }
            catch (Exception)
            {
                
                throw; 
            }
        }


        public Task<Owner> GetByIdAsync(string id)
        {
            var owner =_repository.GetByIdAsync(id);
            return owner;
        }

        public Task UpdateAsync(Owner owner)
        {
            throw new NotImplementedException();
        }
    }
}
