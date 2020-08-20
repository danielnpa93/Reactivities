using System;
using System.Collections.Generic;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence.Data;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityRepository _repository;

        public ActivityController(IActivityRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Activity>> GetActivities()
        {

            var activities = _repository.GetActivities();

            return Ok(activities);

        }

        [HttpGet("{id}")]
        public ActionResult<Activity> GetActivityById(Guid id)
        {
            var activity = _repository.GetActivityById(id);

            if (activity == null)
            {
                return NotFound();

            }

            return Ok(activity);
        }
    }
}