using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ILogger<TicketController> _logger;
        private readonly ITicketRepository _ticketData;

        public TicketController(ILogger<TicketController> logger, ITicketRepository ticketData)
        {
            _logger = logger;
            _ticketData = ticketData;
        }

        [HttpGet("{sprintId}")]
        public IActionResult GetBySprint(int sprintId)
        {
            var result = _ticketData.GetAllBySprint(sprintId);
            return Ok(result);
        }
    }
}
