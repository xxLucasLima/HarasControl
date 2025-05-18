using ArasControl.Application.Commands.Animal;
using ArasControl.Application.Commands.VitaminDose;
using ArasControl.Application.DTOs;
using ArasControl.Application.Queries.Animal;
using ArasControl.Application.Queries.FeedRecord;
using ArasControl.Application.Queries.VaccineRecord;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArasControl.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnimalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAnimalCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAnimalCommand command)
        {
            if (id != command.Id)
                return BadRequest("ID da URL difere do body.");

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteAnimalCommand(id));
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalDto>> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetAnimalByIdQuery(id));
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalDto>>> GetAll()
        {
            var result = await _mediator.Send(new ListAnimalsByOwnerQuery(Guid.Empty));
            return Ok(result);
        }

        [HttpGet("by-owner/{ownerId}")]
        public async Task<ActionResult<IEnumerable<AnimalDto>>> GetByOwner(Guid ownerId)
        {
            var result = await _mediator.Send(new ListAnimalsByOwnerQuery(ownerId));
            return Ok(result);
        }

        [HttpGet("by-haras/{harasId}")]
        public async Task<ActionResult<IEnumerable<AnimalDto>>> GetByHaras(Guid harasId)
        {
            var result = await _mediator.Send(new ListAnimalsByHarasQuery(harasId));
            return Ok(result);
        }

        [HttpGet("{id}/feed-history")]
        public async Task<ActionResult<IEnumerable<FeedRecordDto>>> GetFeedHistory(Guid id)
        {
            var result = await _mediator.Send(new ListFeedRecordsByAnimalQuery(id));
            return Ok(result);
        }

        [HttpGet("{id}/vaccine-history")]
        public async Task<ActionResult<IEnumerable<VaccineRecordDto>>> GetVaccineHistory(Guid id)
        {
            var result = await _mediator.Send(new ListVaccineRecordsByAnimalQuery(id));
            return Ok(result);
        }

        [HttpGet("{id}/vitamin-history")]
        public async Task<ActionResult<IEnumerable<VitaminDoseDto>>> GetVitaminHistory(Guid id)
        {
            var result = await _mediator.Send(new ListVitaminDosesByAnimalQuery(id));
            return Ok(result);
        }
    }
}
