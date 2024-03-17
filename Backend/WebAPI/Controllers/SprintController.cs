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

        [HttpGet]
        public IActionResult GetByDates(DateTime startDate, DateTime endDate)
        {
            if (startDate.Year == 0001 || endDate.Year == 0001)
            {
                return BadRequest();
            }
            
            var result = _sprintData.GetByDates(startDate, endDate);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
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
        
        [HttpGet("{sprintId}/velocity")]
        public IActionResult GetSprintVelocity(int sprintId)
        {
            var prevSprints = _sprintData.GetPreviousSprintsById(sprintId, 3);
            
            if (prevSprints.Count > 0)
            {
                // Get velocity for each sprint
                List<double> velocityCalcs = new List<double>();
                foreach (var sprint in prevSprints)
                {
                    var sprintTickets = _ticketData.GetAllBySprint(sprint.Id);
                    SprintCapacity capacity = StatisticsService.CalculateSprintCapacity(sprintTickets);
                    SprintVelocity velocity = StatisticsService.CalculateSprintVelocity(capacity);
                    velocityCalcs.Add(velocity.Value);
                }
                
                // Return average velocity based on past 1-3 sprints
                SprintVelocity totalAvgVelocity = new SprintVelocity
                {
                    Value = velocityCalcs.Average()
                };
                return Ok(totalAvgVelocity);
            }
            
            return Ok(new List<Sprint>());
        }
    }
}
