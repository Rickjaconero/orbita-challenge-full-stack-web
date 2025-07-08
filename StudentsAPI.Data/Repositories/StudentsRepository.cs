using StudentsAPI.Data.Abstractions;
using StudentsAPI.Data.Abstractions.Repositories;
using StudentsAPI.Domain.Entities;

namespace StudentsAPI.Data.Repositories
{
    internal sealed class StudentsRepository : IStudentsRepository
    {
        private readonly IApplicationContext _context;

        public StudentsRepository(IApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Student> GetByName(string name)
        {
            var students = _context.Students.Where(x => x.Name == name);

            return students;
        }
    }
}