using Domain.Entities;
using Domain.Services;
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
        private readonly ITicketRepository _ticketData;

        public SprintController(ILogger<SprintController> logger, ISprintRepository sprintData, ITicketRepository ticketData)
        {
            _logger = logger;
            _sprintData = sprintData;
            _ticketData = ticketData;
        }

        [HttpGet("currentSprint")]
        public IActionResult GetCurrentOrLastSprint()
        {
            var result = _sprintData.GetCurrentOrLast();
            return Ok(result);
        }

        [HttpGet("{sprintId}/capacity")]
        public IActionResult GetSprintCapacity(int sprintId)
        {
            var sprintTickets = _ticketData.GetAllBySprint(sprintId);
            if (sprintTickets.Count > 0)
            {
                SprintCapacity capacityCalc = StatisticsService.CalculateSprintCapacity(sprintTickets);
                return Ok(capacityCalc);
            }

            return NotFound();
        }
    }
}
