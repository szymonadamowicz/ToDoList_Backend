using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using to_do_list.Data;
using to_do_list.Models;
using to_do_list.Utils;

namespace to_do_list.Controllers;

[ApiController]
[Route("tasks")]
public class TaskController : ControllerBase
{
    private readonly TaskService _taskData;
    private readonly ILogger<TaskController> _logger;

    public TaskController(TaskService taskData, ILogger<TaskController> logger)
    {
        _taskData = taskData;
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TaskDto>> GetTasks()
    {
        var taskModels = _taskData.GetTasks();
        var taskDtos = taskModels.Select(t => t.ToDto());
        return Ok(taskDtos);
    }

    [HttpPost("add")]
    public IActionResult AddTask([FromBody] TaskDto newTask)
    {
        if (newTask == null) return BadRequest(new { message = "Tasks cannot be null" });

        _taskData.AddTask(newTask.ToModel());
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

    [HttpPost("setCompleted")]
    public IActionResult SetCompleted([FromQuery] int task1Id)
    {
        var tasks = _taskData.GetTasks();

        if (!tasks.Any(t => t.Id == task1Id))
            return BadRequest(new { message = "Invalid task IDs." });

        _taskData.SetCompleted(task1Id);
        return Ok(new { message = "Task completion status updated" });
    }

    [HttpPost("editTask")]
    public IActionResult EditTask([FromBody] TaskDto editedTask, [FromQuery] int taskId)
    {
        var tasks = _taskData.GetTasks();

        if (editedTask == null) return BadRequest(new { message = "Tasks cannot be null" });

        if (!tasks.Any(t => t.Id == taskId))
            return BadRequest(new { message = "Invalid task IDs." });

        _taskData.EditTask(editedTask.ToModel(), taskId);
        return Ok(new { message = "Task edited" });
    }
}