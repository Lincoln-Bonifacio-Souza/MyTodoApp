using Microsoft.EntityFrameworkCore;
using MyTodoApp.Models;
using Task = MyTodoApp.Models.Task;

namespace MyTodoApp.Data
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options)
            : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; }
    }
}
