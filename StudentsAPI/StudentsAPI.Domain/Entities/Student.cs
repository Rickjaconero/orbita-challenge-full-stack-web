namespace StudentsAPI.Domain.Entities
{
    public sealed class Student
    {
        public Guid AcademicRegistry {  get; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Cpf { get; }

        public Student(
            Guid academicRegistry,
            string name,
            string email,
            string cpf)
        {
            AcademicRegistry = academicRegistry;
            Name = name;
            Email = email;
            Cpf = cpf;
        }
    }
}