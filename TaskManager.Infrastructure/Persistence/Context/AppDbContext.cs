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
        public DbSet<TaskItem> TaskItems => Set<TaskItem>();
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<TaskStage> TaskStages => Set<TaskStage>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 🔹 TaskItem → Project (Restrict)
            modelBuilder.Entity<TaskItem>()
                .HasOne(t => t.Project)
                .WithMany(p => p.TaskItems)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            // 🔹 TaskItem → TaskStage (Restrict)
            modelBuilder.Entity<TaskItem>()
                 .HasOne(t => t.TaskStage)
                 .WithMany(ts => ts.TaskItems)
                 .HasForeignKey(t => t.TaskStageId)
                 .OnDelete(DeleteBehavior.Restrict);



            // 🔹 TaskItem → AssignedEmployee (Restrict)
            modelBuilder.Entity<TaskItem>()
                .HasOne(t => t.AssignedEmployee)
                .WithMany(e => e.AssignedTasks)
                .HasForeignKey(t => t.AssignedTo)
                .OnDelete(DeleteBehavior.Restrict);

            // 🔹 TaskItem → AssignedUser (Restrict)
            modelBuilder.Entity<TaskItem>()
                .HasOne(t => t.AssignedUser)
                .WithMany(u => u.CreatedTasks)
                .HasForeignKey(t => t.AssignedBy)
                .OnDelete(DeleteBehavior.Restrict);

            // 🔹 Comment → TaskItem (Only one allowed as Cascade)
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.TaskItems)
                .WithMany(t => t.Comments)
                .HasForeignKey(c => c.TaskItemId)
                .OnDelete(DeleteBehavior.Cascade); // ✅ Safe cascade

            // 🔹 Comment → User (Restrict)
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
