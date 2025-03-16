using Microsoft.AspNetCore.Mvc;
using to_do_list.Data;
using to_do_list.Models;

namespace to_do_list.Controllers;

[ApiController]
[Route("tasks")]
public class Task_controller : ControllerBase
{
    private readonly Task_data _taskData;
    private readonly ILogger<Task_controller> _logger;

    public Task_controller(Task_data taskData, ILogger<Task_controller> logger)
    {
        _taskData = taskData;
        _logger = logger;
    }

    [HttpGet(Name = "GetTask")]
    public IEnumerable<Task_model> Get()
    {
        return _taskData.GetTasks();
    }
}
