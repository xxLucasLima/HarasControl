using ArasControl.Application.Commands.VitaminDose;
using ArasControl.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArasControl.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VitaminDoseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VitaminDoseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Add([FromBody] AddVitaminDoseCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpGet("by-animal/{animalId}")]
        public async Task<ActionResult<IEnumerable<VitaminDoseDto>>> GetByAnimal(Guid animalId)
        {
            var result = await _mediator.Send(new ListVitaminDosesByAnimalQuery(animalId));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VitaminDoseDto>> GetById(Guid id)
        {
            // Opcional: se quiser buscar uma dose específica por id, crie a query correspondente
            return NotFound(); // placeholder
        }
    }
}
