using Microsoft.EntityFrameworkCore;
using ToDoListEF.Domain.Entity;

namespace ToDoListEF.DAL;

public class AppDbContext : DbContext
{
    public  AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    public DbSet<TaskEntity> Tasks { get; set; }
}