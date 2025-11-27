using Microsoft.EntityFrameworkCore;
using TaskManager.Shared.Models;

namespace TaskManager.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la relación User = UserTasks
            modelBuilder.Entity<User>()
                .HasMany(u => u.Tasks)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuración opcional para SQLite (evita problemas de tipos)
            modelBuilder.Entity<User>().Property(u => u.Name).HasColumnType("TEXT");
            modelBuilder.Entity<User>().Property(u => u.Email).HasColumnType("TEXT");
            modelBuilder.Entity<User>().Property(u => u.Password).HasColumnType("TEXT");

            modelBuilder.Entity<UserTask>().Property(t => t.Title).HasColumnType("TEXT");
            modelBuilder.Entity<UserTask>().Property(t => t.Description).HasColumnType("TEXT");
            modelBuilder.Entity<UserTask>().Property(t => t.CreatedAt).HasColumnType("TEXT");
        }
    }
}
