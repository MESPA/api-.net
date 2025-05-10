using Microsoft.EntityFrameworkCore;
using UserManagementAPI.Domain.Entities;

namespace UserManagementAPI.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {            Database.EnsureCreated(); // Esto creará la base de datos si no existe
            if (Database.EnsureCreated())
            {
                // Seed data inicial
                if (!Users.Any(u => true))
                {
                    Users.Add(new User
                    {
                        Id = Guid.NewGuid(),
                        Username = "admin",
                        Email = "admin@example.com",
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123"),
                        Role = "Admin",
                        CreatedAt = DateTime.UtcNow,
                        IsActive = true
                    });
                    SaveChanges();
                }
            }
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.Property(e => e.PasswordHash).IsRequired();
                entity.Property(e => e.Role).IsRequired();
                entity.HasIndex(e => e.Username).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
            });
        }
    }
}
