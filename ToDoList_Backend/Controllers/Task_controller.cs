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
    [HttpPost("add")]
    public IActionResult AddTask([FromBody] Task_model newTask)
    {
        if (newTask == null)
        {
            return BadRequest("Task cannot be null.");
        }

        _taskData.AddTask(newTask);
        return CreatedAtAction(nameof(Get), newTask);
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteTask(int id)
    {
        var task = _taskData.GetTasks().FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            return NotFound();
        }

        foreach (var t in _taskData.GetTasks())
        {
            if (t.Id > id)
            {
                t.Id--;
            }
        }

        _taskData.RemoveTask(id);
        return NoContent();
    }

    [HttpPost("swap")]
    public IActionResult SwapTasks([FromQuery] int task1Id, [FromQuery] int task2Id)
    {
        _taskData.SwapTasks(task1Id, task2Id);
        return NoContent();
    }
}
