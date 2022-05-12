using Microsoft.EntityFrameworkCore;

namespace Task.API.Models.Context
{
    public class TasksDbContext : DbContext
    {
        public TasksDbContext()
        {
        }

        public TasksDbContext(DbContextOptions<TasksDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<TaskModel> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }

    }
}
