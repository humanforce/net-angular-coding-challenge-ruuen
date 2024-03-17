using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicHolidayController : ControllerBase
    {
        private readonly ILogger<PublicHolidayController> _logger;
        private readonly IPublicHolidayRepository _publicHolidayData;

        public PublicHolidayController(ILogger<PublicHolidayController> logger, IPublicHolidayRepository publicHolidayData)
        {
            _logger = logger;
            _publicHolidayData = publicHolidayData;
        }

        [HttpGet]
        public IActionResult GetAllInDateRange(DateTime startDate, DateTime endDate)
        {
            if (startDate.Year != 0001 || endDate.Year != 0001)
            {
                var results = _publicHolidayData.GetAllInDateRange(startDate, endDate);
                return Ok(results);
            }

            return BadRequest();
        }
    }
}
