using StudentsAPI.Domain.Entities;

namespace StudentsAPI.Data.Abstractions.Repositories
{
    public interface IStudentsRepository
    {
        IEnumerable<Student> GetByName(string name);
    }
}