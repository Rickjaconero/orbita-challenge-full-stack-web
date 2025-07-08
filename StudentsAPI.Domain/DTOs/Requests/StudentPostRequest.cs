namespace StudentsAPI.Domain.DTOs.Requests
{
    public sealed class StudentPostRequest
    {
        public string Name { get; }

        public string Email { get; }

        public string Cpf { get; }

        public StudentPostRequest(
            string name,
            string email,
            string cpf)
        {
            Name = name;
            Email = email;
            Cpf = cpf;
        }
    }
}