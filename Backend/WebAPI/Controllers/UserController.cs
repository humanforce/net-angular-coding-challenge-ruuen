using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userData;

        public UserController(ILogger<UserController> logger, IUserRepository userData)
        {
            _logger = logger;
            _userData = userData;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _userData.GetAll();
            return Ok(result);
        }
    }
}
