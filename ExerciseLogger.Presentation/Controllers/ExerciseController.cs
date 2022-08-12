using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace ExerciseLogger.Presentation.Controllers
{
    [Route("api/gyms/{gymId}/exercises")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IServiceManager _service;

        public ExerciseController (IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetExercisesFromGym(Guid gymId)
        {
            var exercises = _service.ExerciseService.GetExercises(gymId, trackChanges: false);

            return Ok(exercises);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetExercise(Guid gymId, Guid exerciseId)
        { 
            var exercise = _service.ExerciseService.GetExercise(gymId, exerciseId, trackChanges: false);
            return Ok(exercise);
        }
    }
}
