﻿using ToDoListEF.Domain.Enum;

namespace ToDoListEF.Domain.Entity;

public class TaskEntity
{
    public long Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public DateTime Created { get; set; }
    
    public Priority Priority { get; set; }
    
    public bool IsDone { get; set; }

}