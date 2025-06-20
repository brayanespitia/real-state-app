using Microsoft.AspNetCore.Mvc;
using RealStateApp.Application.Dto;
using RealStateApp.Application.Interfaces;
using RealStateApp.Domain.Entities;

namespace RealStateApp.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _service;

        public OwnerController(IOwnerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Owner>>> GetAll()
        {
            var owners = await _service.GetAllAsync();
            return Ok(owners);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Owner>> GetById(string id)
        {
            var owner = await _service.GetByIdAsync(id);
            if (owner == null) return NotFound();
            return Ok(owner);
        }

        [HttpPost]
        public async Task<ActionResult> Create(OwnerDto dto)
        {
            var createdOwner = await _service.AddAsync(dto);
            return Ok(createdOwner);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, Owner owner)
        {
            if (id != owner.IdOwner) return BadRequest();
            await _service.UpdateAsync(owner);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
