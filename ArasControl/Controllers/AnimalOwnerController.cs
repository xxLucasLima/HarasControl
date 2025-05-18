using ArasControl.Application.Commands.AnimalOwner;
using ArasControl.Application.DTOs;
using ArasControl.Application.Queries.AnimalOwner;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArasControl.WebApi.Controllers
{
    [Authorize(Roles = "AnimalOwner")]
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalOwnerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnimalOwnerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAnimalOwnerCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAnimalOwnerCommand command)
        {
            if (id != command.Id)
                return BadRequest("ID da URL difere do body.");

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteAnimalOwnerCommand(id));
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalOwnerDto>>> GetAll()
        {
            var result = await _mediator.Send(new ListAnimalOwnersQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalOwnerDto>> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetAnimalOwnerByIdQuery(id));
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("by-haras/{harasId}")]
        public async Task<ActionResult<IEnumerable<AnimalOwnerDto>>> GetByHaras(Guid harasId)
        {
            var result = await _mediator.Send(new ListAnimalOwnersByHarasQuery(harasId));
            return Ok(result);
        }
    }
}
