using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace ExerciseLogger.Presentation.Controllers
{
    [Route("api/gyms")]
    [ApiController]
    public class GymsController : ControllerBase
    {
        private readonly IServiceManager _service;

        public GymsController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetGyms()
        {
            var gyms = _service.GymService.GetAllGyms(trackChanges: false);

            return Ok(gyms);
        }

        [HttpGet("{Id:Guid}", Name = "GymById")]
        public IActionResult GetGym(Guid id)
        {
            var gym = _service.GymService.GetGym(id, trackChanges: false);

            return Ok(gym);
        }

        [HttpPost]
        public IActionResult CreateGym([FromBody] GymForCreationDto gym)
        {
            if (gym is null)
            {
                return BadRequest("GymForCreationDto object is null");
            }

            var createdGym = _service.GymService.CreateGym(gym);

            return CreatedAtRoute("GymById", new { id = createdGym.Id }, createdGym);
        }

    }
}
