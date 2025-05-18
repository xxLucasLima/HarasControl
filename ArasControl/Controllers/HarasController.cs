using ArasControl.Application.Commands.Haras;
using ArasControl.Application.DTOs;
using ArasControl.Application.Queries.Haras;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArasControl.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HarasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HarasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateHarasCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateHarasCommand command)
        {
            if (id != command.Id)
                return BadRequest("ID da URL difere do body.");

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteHarasCommand(id));
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _mediator.Send(new ListHarasQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HarasDto>> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetHarasByIdQuery(id));
            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
