using ArasControl.Application.Commands.FeedInventory;
using ArasControl.Application.DTOs;
using ArasControl.Application.Queries.FeedInventory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArasControl.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedInventoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FeedInventoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateFeedInventoryCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateFeedInventoryCommand command)
        {
            if (id != command.Id)
                return BadRequest("ID da URL difere do body.");

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FeedInventoryDto>> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetFeedInventoryByIdQuery(id));
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("by-animal/{animalId}")]
        public async Task<ActionResult<FeedInventoryDto>> GetByAnimal(Guid animalId)
        {
            var result = await _mediator.Send(new GetFeedInventoryByAnimalIdQuery(animalId));
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedInventoryDto>>> GetAll()
        {
            var result = await _mediator.Send(new ListAllFeedInventoriesQuery());
            return Ok(result);
        }
    }
}
