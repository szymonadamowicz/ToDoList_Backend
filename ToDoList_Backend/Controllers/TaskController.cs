using Microsoft.AspNetCore.Mvc;
using to_do_list.Data;
using to_do_list.Models;

namespace to_do_list.Controllers;

[ApiController]
[Route("tasks")]
public class TaskController : ControllerBase
{
    private readonly TaskData _taskData;
    private readonly ILogger<TaskController> _logger;

    public TaskController(TaskData taskData, ILogger<TaskController> logger)
    {
        _taskData = taskData;
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TaskModel>> GetTasks() => Ok(_taskData.GetTasks());

    [HttpPost("add")]
    public IActionResult AddTask([FromBody] TaskModel newTask)
    {
        if (newTask == null) return BadRequest(new { message = "Tasks cannot be null" });
        _taskData.AddTask(newTask);
        return Ok(new { message = "Task added", task = newTask });
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTask(int id)
    {
        var removed = _taskData.RemoveTask(id);
        return removed ? Ok(new { message = "Task removed" }) : NotFound();
    }

    [HttpPost("swap")]
    public IActionResult SwapTasks([FromQuery] int task1Id, [FromQuery] int task2Id)
    {
        var tasks = _taskData.GetTasks();

        if (!tasks.Any(t => t.Id == task1Id) || !tasks.Any(t => t.Id == task2Id))
            return BadRequest(new { message = "Invalid task IDs." });

        _taskData.SwapTasks(task1Id, task2Id);
        return Ok(new { message = "Tasks swapped" });
    }
}
