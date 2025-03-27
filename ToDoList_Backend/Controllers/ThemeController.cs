using Microsoft.AspNetCore.Mvc;
using ToDoList_Backend.Models;
using ToDoList_Backend.Service;

[ApiController]
[Route("theme")]
public class SettingsController : ControllerBase
{
    private readonly ThemeService _themeData;

    public SettingsController(ThemeService themeData)
    {
        _themeData = themeData;
    }

    [HttpGet()]
    public ActionResult<IsDarkModel> GetTheme()
    {
        var theme = _themeData.GetTheme();
        return Ok(theme);
    }

    [HttpPost("changeTheme")]
    public IActionResult SetTheme()
    {
        _themeData.ChangeTheme();
        return Ok(new { message = "theme changed" });
    }
}
