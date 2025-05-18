using ArasControl.Application.Commands.FeedRecord;
using ArasControl.Application.DTOs;
using ArasControl.Application.Queries.FeedRecord;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArasControl.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedRecordController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FeedRecordController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Add([FromBody] AddFeedRecordCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpGet("by-animal/{animalId}")]
        public async Task<ActionResult<IEnumerable<FeedRecordDto>>> GetByAnimal(Guid animalId)
        {
            var result = await _mediator.Send(new ListFeedRecordsByAnimalQuery(animalId));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FeedRecordDto>> GetById(Guid id)
        {
            // Opcional, se quiser buscar feed record específico por id (só se implementou a query correspondente)
            return NotFound(); // placeholder
        }
    }
}
