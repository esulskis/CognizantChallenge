using CognizantChallenge.Models;
using CognizantChallenge.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CognizantChallenge.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController: ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService) {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tasks = await _taskService.GetTasks();
            return  Ok(tasks);
        }

        [HttpPost("SubmitTaskSolution")]
        public async Task<IActionResult> SubmitTaskSolution([FromBody] TaskSolutionModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _taskService.SubmitTaskSolution(model, userId);
            return Ok(result);
        }
    }
}
