using ArasControl.Application.Commands.VaccineRecord;
using ArasControl.Application.DTOs;
using ArasControl.Application.Queries.VaccineRecord;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArasControl.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VaccineRecordController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VaccineRecordController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Add([FromBody] AddVaccineRecordCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpGet("by-animal/{animalId}")]
        public async Task<ActionResult<IEnumerable<VaccineRecordDto>>> GetByAnimal(Guid animalId)
        {
            var result = await _mediator.Send(new ListVaccineRecordsByAnimalQuery(animalId));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VaccineRecordDto>> GetById(Guid id)
        {
            // Opcional: se quiser buscar uma vacina específica por id, crie a query correspondente
            return NotFound(); // placeholder
        }
    }
}
