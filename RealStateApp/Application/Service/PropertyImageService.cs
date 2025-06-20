using AutoMapper;
using RealStateApp.Application.Dto;
using RealStateApp.Application.Interfaces;
using RealStateApp.Domain.Entities;
using RealStateApp.Domain.Repository;
using RealStateApp.Infraestructure.Repository;

namespace RealStateApp.Application.Service
{
    public class PropertyImageService : IPropertyImageService
    {
        private readonly IPropertyImageRepository _repository;
        private readonly IMapper _mapper;

        public PropertyImageService(IPropertyImageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        public async Task<PropertyImageDto>  AddAsync(PropertyImageDto dto)
        {
            var property = _mapper.Map<PropertyImage>(dto);
            await _repository.AddAsync(property);
            return _mapper.Map<PropertyImageDto>(property);
        }

        public async Task<List<PropertyImageDto>> GetAllAsync()
        {
            try
            {
                var propertyImages = await _repository.GetAllAsync();
                if (!propertyImages.Any())
                    return new List<PropertyImageDto>();

                return _mapper.Map<List<PropertyImageDto>>(propertyImages);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<PropertyImageDto> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
        public async Task<List<PropertyImageDto>> GetByPropertyIdAsync(string propertyId)
        {
            var images = await _repository.GetPropertysById(propertyId);
            return _mapper.Map<List<PropertyImageDto>>(images);
        }

    }
}
