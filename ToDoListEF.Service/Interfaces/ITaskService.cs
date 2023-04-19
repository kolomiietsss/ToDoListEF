using ToDoListEF.Domain.Entity;
using ToDoListEF.Domain.Response;
using ToDoListEF.Domain.ViewModels.Task;

namespace ToDoListEF.Service.Interfaces;

public interface ITaskService
{
    // для возврата главного обьекта, с описанием, что произошло
    Task<IBaseResponse<TaskEntity>> Create(CreateTaskViewModel model);
    
}