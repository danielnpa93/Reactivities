using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ActivitiesController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activity>>> GetAllActivities()
        {
            var activities = await _mediator.Send(new ActivitiesFindQuery.Query());
            return Ok(activities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivityById(Guid id)
        {
            var activity = await _mediator.Send(new ActivityFindByIdQuery.Query { Id = id });
            return Ok(activity);

        }

        [HttpPost]
        public async Task<ActionResult<Activity>> CreateActivity([FromBody] ActivitiesCreateCommand.Command command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> UpdateActivity (Guid id, [FromBody] ActivitiesUpdateCommand.Command command)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> DeleteActivity(Guid id)
        {
            return await _mediator.Send(new ActivityRemove.Command { Id = id });
        }
    }
}