using Microsoft.AspNetCore.Mvc;
using Services.Iservice;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        

        private readonly ILogger<TasksController> _logger;
        private readonly ITasksService _TasksService;
        public TasksController(ITasksService TasksService, ILogger<TasksController> logger)
        {
            _TasksService = TasksService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetName()
        {
            var task = await _TasksService.Get();
            return Ok(task);
        }
    }
}
