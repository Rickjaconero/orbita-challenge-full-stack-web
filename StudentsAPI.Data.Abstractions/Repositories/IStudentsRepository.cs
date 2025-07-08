using StudentsAPI.Domain.Entities;

namespace StudentsAPI.Data.Abstractions.Repositories
{
    public interface IStudentsRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetByAcademicRegistry(Guid academicRegistry);
        Task<IEnumerable<Student>> GetByNameAsync(string name);
        Task AddAsync(Student student);
        Task RemoveAsync(Student student);
        Task SaveChangesAsync();
    }
}