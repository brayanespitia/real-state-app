using AutoMapper;
using RealStateApp.Application.Dto;
using RealStateApp.Application.Interfaces;
using RealStateApp.Domain.Entities;
using RealStateApp.Domain.Repository;
using System.Data;

namespace RealStateApp.Application.Service
{
    public class PropertyService : IPropertyService
    {

        private readonly IPropertyRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPropertyImageRepository _imageRepository;

        public PropertyService(IPropertyRepository repository, IMapper mapper, IPropertyImageRepository imageRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _imageRepository = imageRepository;
        }

        public async Task <PropertyDto>  AddAsync(PropertyDto dto)
        {
            var property = _mapper.Map<Property>(dto);
            await _repository.AddAsync(property);
            return _mapper.Map<PropertyDto>(property);
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PropertyDto>> GetAllAsync()
        {
            var properties = await _repository.GetAllAsync();

            if (!properties.Any())
                return new List<PropertyDto>();

            var propertyDtos = new List<PropertyDto>();

            foreach (var property in properties)
            {
                // Traer primera imagen relacionada a esta propiedad
                var image = await _imageRepository.GetFirstImageByPropertyIdAsync(property.IdProperty);

                propertyDtos.Add(new PropertyDto
                {
                    Name = property.Name,
                    Address = property.Address,
                    Price = property.Price,
                    CodeInternal = property.CodeInternal,
                    Year = property.Year,
                    IdOwner = property.IdOwner,
                    ImageBase64 = image?.File,
                    id = property.IdProperty
                });
            }

            return propertyDtos;
        }


        public Task<Property> GetByIdAsync(string id)
        {
            var property = _repository.GetByIdAsync(id);
            return property;
        }

        public Task UpdateAsync(Property property)
        {
            throw new NotImplementedException();
        }
    }
}
