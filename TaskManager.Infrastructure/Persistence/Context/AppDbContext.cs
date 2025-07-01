using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users => Set<User>();
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<TaskStage> TaskStages => Set<TaskStage>(); 
    }
}
