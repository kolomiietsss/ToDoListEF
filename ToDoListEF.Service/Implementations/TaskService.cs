using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ToDoListEF.DAL.Interfaces;
using ToDoListEF.Domain.Entity;
using ToDoListEF.Domain.Enum;
using ToDoListEF.Domain.Response;
using ToDoListEF.Domain.ViewModels.Task;
using ToDoListEF.Service.Interfaces;

namespace ToDoListEF.Service.Implementations;

public class TaskService : ITaskService
{

    private readonly IBaseRepository<TaskEntity> _taskRepository;
    private ILogger<TaskService> _logger;


    public TaskService(IBaseRepository<TaskEntity> taskRepository, ILogger<TaskService> logger)
    {
        _taskRepository = taskRepository;
        _logger = logger;
    }

    public async Task<IBaseResponse<TaskEntity>> Create(CreateTaskViewModel model)
    {
        try
        {
            _logger.LogInformation($"Request to create task - {model.Name}");

            var task = await _taskRepository.GetAll()
                .Where(x => x.Created.Date == DateTime.Today)
                .FirstOrDefaultAsync(x => x.Name == model.Name);

            if (task != null)
            {
                return new BaseResponse<TaskEntity>()
                {
                    Description = "Error! Task exists!",
                    StatusCode = StatusCode.TaskWithSameNameExists
                };
            }

            task = new TaskEntity()
            {
                Name = model.Name,
                Description = model.Description,
                Priority = model.Priority,
                Created = DateTime.Now,
                IsDone = false
            };
            await _taskRepository.Create(task);
            
            _logger.LogInformation($"Task created: {task.Name} {task.Created}");
            return new BaseResponse<TaskEntity>()
            {
                StatusCode = StatusCode.OK,
                Description = "Task created"
            };
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"[TaskService.Create]: {e.Message}");
            return new BaseResponse<TaskEntity>()
            {
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}