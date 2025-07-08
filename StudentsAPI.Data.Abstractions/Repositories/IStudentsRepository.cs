using StudentsAPI.Domain.Entities;

namespace StudentsAPI.Data.Abstractions.Repositories
{
    public interface IStudentsRepository
    {
        Task<IEnumerable<Student>> GetAsync();
        Task<Student> GetByAcademicRegistryAsync(Guid academicRegistry);
        Task<IEnumerable<Student>> GetByNameAsync(string name);
        Task<bool> IsCpfAlreadyRegisteredAsync(string cpf);
        Task AddAsync(Student student);
        void Remove(Student student);
        Task SaveChangesAsync();
    }
}