using StudentsAPI.Domain.Entities;

namespace StudentsAPI.Domain.DTOs.Responses
{
    public sealed class StudentGetResponse
    {
        public Guid AcademicRegistry { get; }

        public string Name { get; }

        public string Email { get; }

        public string Cpf { get; }

        public StudentGetResponse(Student student)
        {
            AcademicRegistry = student.AcademicRegistry;
            Name = student.Name;
            Email = student.Email;
            Cpf = student.Cpf;
        }
    }
}