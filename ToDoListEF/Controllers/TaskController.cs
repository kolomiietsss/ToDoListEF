using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoListEF.Domain.ViewModels.Task;

namespace ToDoListEF.Controllers;

public class TaskController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTaskViewModel model)
    {
        return Ok();
    }
}