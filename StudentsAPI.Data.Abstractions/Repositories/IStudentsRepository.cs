using StudentsAPI.Domain.Entities;

namespace StudentsAPI.Data.Abstractions.Repositories
{
    public interface IStudentsRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetByAcademicRegistry(Guid academicRegistry);
        Task<IEnumerable<Student>> GetByNameAsync(string name);
        Task<bool> IsCpfAlreadyRegistered(string cpf);
        Task AddAsync(Student student);
        void Remove(Student student);
        Task SaveChangesAsync();
    }
}