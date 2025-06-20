using Microsoft.AspNetCore.Mvc;
using RealStateApp.Application.Dto;
using RealStateApp.Application.Interfaces;
using RealStateApp.Domain.Entities;

namespace RealStateApp.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertyImageController : ControllerBase
    {
        private readonly IPropertyImageService _service;

        public PropertyImageController(IPropertyImageService service)
        {
            _service = service;
            
        }

        [HttpPost]
        public async Task<ActionResult> Create(PropertyImageDto imageDto)
        {
            var image = await _service.AddAsync(imageDto);
            return Ok(image);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyImageDto>>> GetAll()
        {
            var perotyImages = await _service.GetAllAsync();
            return Ok(perotyImages);
        }

        [HttpGet("Properties/{propertyId}")]
        public async Task<ActionResult<IEnumerable<PropertyImageDto>>> GetByProperty(string propertyId)
        {
            var result = await _service.GetByPropertyIdAsync(propertyId);
            return Ok(result);
        }
    }
}
