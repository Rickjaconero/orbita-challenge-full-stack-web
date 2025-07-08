using Microsoft.EntityFrameworkCore;
using StudentsAPI.Domain.Entities;

namespace StudentsAPI.Data.Abstractions
{
    public interface IApplicationContext
    {
        public DbSet<Student> Students { get; set; }
    }
}