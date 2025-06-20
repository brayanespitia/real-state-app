using Microsoft.AspNetCore.Mvc;
using RealStateApp.Application.Dto;
using RealStateApp.Application.Interfaces;
using RealStateApp.Domain.Entities;

namespace RealStateApp.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertyController :ControllerBase
    {
        private readonly IPropertyService _service;
        private readonly IOwnerService _ownerService;
        private readonly IPropertyImageService _propertyImageService;

        public PropertyController(IPropertyService service, IOwnerService ownerService, IPropertyImageService propertyImageService)
        {
            _service = service;
            _ownerService = ownerService;
            _propertyImageService = propertyImageService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Property>>> GetAll()
        {
            var properties = await _service.GetAllAsync();
            return Ok(properties);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Property>> GetById(string id)
        {
            var property = await _service.GetByIdAsync(id);
            if (property == null) return NotFound();
            return Ok(property);
        }

        [HttpPost]
        public async Task<ActionResult> Create(PropertyDto propertyDto)
        {
            var property  =await _service.AddAsync(propertyDto);
            return Ok (property);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, Property property)
        {
            if (id != property.IdProperty) return BadRequest();
            await _service.UpdateAsync(property);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("Properties/{id}")]
        public async Task<IActionResult> GetPropertyDetails(string id)
        {
            var property = await _service.GetByIdAsync(id);
            if (property == null) return NotFound();

            var owner = await _ownerService.GetByIdAsync(property.IdOwner);
            var images = await _propertyImageService.GetByPropertyIdAsync(id);

            var response = new
            {
                property,
                owner,
                images
            };

            return Ok(response);
        }

    }
}
