using Microsoft.EntityFrameworkCore;
using StudentsAPI.Domain.Entities;

namespace StudentsAPI.Data.Abstractions
{
    public interface IApplicationContext
    {
        DbSet<Student> Students { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}