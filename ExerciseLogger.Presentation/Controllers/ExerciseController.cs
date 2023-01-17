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
    [Route("api/gyms/{gymId}/exercises")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IServiceManager _service;

        public ExerciseController (IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetExercisesForGym(Guid gymId)
        {
            var exercise = _service.ExerciseService.GetExercises(gymId, trackChanges: false);
            return Ok(exercise);

        }

        [HttpGet("{id:guid}", Name = "GetExerciseForGym")]
        public IActionResult GetExerciseForGym(Guid gymId, Guid id)
        {
            var exercises = _service.ExerciseService.GetExercise(gymId, id, trackChanges: false);

            return Ok(exercises);
        }

        [HttpPost]
        public IActionResult CreateExerciseForGym(Guid gymId, [FromBody] ExerciseForCreationDto exercise)
        {
            if (exercise is null)
            {
                return BadRequest("ExerciseForCreationDto object is null");
            }

            var exerciseToReturn = _service.ExerciseService.CreateExerciseForGym(gymId, exercise, trackingChanges: false);

            return CreatedAtRoute("GetExerciseForGym", new { gymId, id = exerciseToReturn.Id }, exerciseToReturn);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteExerciseForGym(Guid gymId, Guid id)
        {
            _service.ExerciseService.DeleteExerciseForGym(gymId, id, trackChanges: false);

            return NoContent();
        }
    }
}
