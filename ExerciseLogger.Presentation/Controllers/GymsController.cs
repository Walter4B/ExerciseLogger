using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

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
            try
            {
                var gyms = _service.GymService.GetAllGyms(trackChanges: false);
                return Ok(gyms);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
