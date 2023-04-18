using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoListEF.Domain.ViewModels.Task;
using ToDoListEF.Service.Interfaces;

namespace ToDoListEF.Controllers;

public class TaskController : Controller
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTaskViewModel model)
    {
        var response = await _taskService.Create(model);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return Ok(new { description = response.Description });
        }
        return BadRequest(new { description = response.Description });
    }
}