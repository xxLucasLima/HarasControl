using ArasControl.Application.Commands.HarasOwner;
using ArasControl.Application.DTOs;
using ArasControl.Application.Queries.HarasOwner;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArasControl.WebApi.Controllers
{
    [Authorize(Roles = "HarasOwner")]
    [ApiController]
    [Route("api/[controller]")]
    public class HarasOwnerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HarasOwnerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateHarasOwnerCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateHarasOwnerCommand command)
        {
            if (id != command.Id)
                return BadRequest("ID da URL difere do body.");

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteHarasOwnerCommand(id));
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var result = await _mediator.Send(new ListHarasOwnersQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HarasOwnerDto>> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetHarasOwnerByIdQuery(id));
            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
