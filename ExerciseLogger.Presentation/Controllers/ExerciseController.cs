using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.JsonPatch;
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
        public async Task<IActionResult> GetExercisesForGym(Guid gymId)
        {
            var exercise = await _service.ExerciseService.GetExercisesAsync(gymId, trackChanges: false);
            return Ok(exercise);

        }

        [HttpGet("{id:guid}", Name = "GetExerciseForGym")]
        public async Task<IActionResult> GetExerciseForGym(Guid gymId, Guid id)
        {
            var exercises = await _service.ExerciseService.GetExerciseAsync(gymId, id, trackChanges: false);

            return Ok(exercises);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExerciseForGym(Guid gymId, [FromBody] ExerciseForCreationDto exercise)
        {
            if (exercise is null)
            {
                return BadRequest("ExerciseForCreationDto object is null");
            }
            if (!ModelState.IsValid) 
            {
                return UnprocessableEntity(ModelState);
            }

            var exerciseToReturn = await _service.ExerciseService.CreateExerciseForGymAsync(gymId, exercise, trackingChanges: false);

            return CreatedAtRoute("GetExerciseForGym", new { gymId, id = exerciseToReturn.Id }, exerciseToReturn);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteExerciseForGym(Guid gymId, Guid id)
        {
            await _service.ExerciseService.DeleteExerciseForGymAsync(gymId, id, trackChanges: false);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateExerciseForGym(Guid gymId, Guid id, [FromBody] ExerciseForUpdateDto exercise)
        { 
            if(exercise is null)
            {
                return BadRequest("ExerciseForUpdateDto object is null");
            }
            if(!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            await _service.ExerciseService.UpdateExerciseForGymAsync(gymId, id, exercise, gymTrackChanges: false, exerTrackChanges: true);
            return NoContent();
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> PartiallyUpdateExerciseForGym(Guid gymId, Guid id, [FromBody] JsonPatchDocument<ExerciseForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
            {
                return BadRequest("patchDoc object is null.");
            }

            var result = await _service.ExerciseService.GetExerciseForPatchAsync(gymId, id, gymTrackChanges: false, exerTrackChanges: true);
            patchDoc.ApplyTo(result.exerciseToPatch, ModelState);

            TryValidateModel(result.exerciseToPatch);

            if(!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            await _service.ExerciseService.SaveChangesForPatchAsync(result.exerciseToPatch, result.exerciseEntity);

            return NoContent();
        }
    }
}
