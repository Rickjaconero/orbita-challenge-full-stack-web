using Microsoft.EntityFrameworkCore;
using StudentsAPI.Data.Abstractions;
using StudentsAPI.Data.Configurations;
using StudentsAPI.Domain.Entities;

namespace StudentsAPI.Data
{
    public sealed class ApplicationContext : DbContext, IApplicationContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql("Host=localhost;Database=orbita;Username=postgres;Password=123")
                .EnableSensitiveDataLogging()
                .LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
        }
    }
}