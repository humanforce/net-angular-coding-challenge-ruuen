using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SprintController : ControllerBase
    {
        private readonly ILogger<SprintController> _logger;
        private readonly ISprintRepository _sprintData;

        public SprintController(ILogger<SprintController> logger, ISprintRepository sprintData)
        {
            _logger = logger;
            _sprintData = sprintData;
        }

        [HttpGet("currentSprint")]
        public IActionResult GetCurrentOrLastSprint()
        {
            var result = _sprintData.GetCurrentOrLast();
            return Ok(result);
        }
    }
}
