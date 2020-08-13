using CognizantChallenge.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CognizantChallenge.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TopUsersController : ControllerBase
    {
        private ITopUsersService _topUsersService;
        public TopUsersController(ITopUsersService topUsersService) {
            _topUsersService = topUsersService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var response = _topUsersService.GetTopUsers();
            return Ok(response);
        }
    }
}
