using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExerciseLogger.Presentation.ModelBinders;
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
        public async Task<IActionResult> GetGyms()
        {
            var gyms = await _service.GymService.GetAllGymsAsync(trackChanges: false);

            return Ok(gyms);
        }

        [HttpGet("{Id:Guid}", Name = "GymById")]
        public async Task<IActionResult> GetGym(Guid id)
        {
            var gym = await _service.GymService.GetGymAsync(id, trackChanges: false);

            return Ok(gym);
        }

        [HttpGet("collection/({ids})", Name = "GymCollection")]
        public async Task<IActionResult> GetGymCollection([ModelBinder (BinderType = typeof(ArrayModelBinder))]IEnumerable<Guid> ids)
        {
            var gyms = await _service.GymService.GetByIdsAsync(ids, trackChanges: false);
            
            return Ok(gyms);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGym([FromBody] GymForCreationDto gym)
        {
            if (gym is null)
            {
                return BadRequest("GymForCreationDto object is null");
            }
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var createdGym = await _service.GymService.CreateGymAsync(gym);

            return CreatedAtRoute("GymById", new { id = createdGym.Id }, createdGym);
        }

        [HttpPost("collection")]
        public async Task<IActionResult> CreateGymCollection([FromBody] IEnumerable<GymForCreationDto> gymCollection)
        { 
            var result = await _service.GymService.CreateGymCollectionAsync(gymCollection);

            return CreatedAtRoute("GymCollection", new { result.ids }, result.gyms);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteGym(Guid id)
        {
            await _service.GymService.DeleteGymAsync(id, trackChanges: false);

            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateGym(Guid id, [FromBody] GymForUpdateDto gym)
        {
            if(gym is null)
            { 
                return BadRequest("GymForUpdateDto is null");
            }
            if (!ModelState.IsValid)
            {
                UnprocessableEntity(ModelState);
            }

            await _service.GymService.UpdateGymAsync(id, gym, trackChanges: true);

            return NoContent();
        }
    }
}
