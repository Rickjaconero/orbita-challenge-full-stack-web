namespace StudentsAPI.Domain.DTOs.Requests
{
    public sealed class StudentPutRequest
    {
        public string Name { get; }

        public string Email { get; }

        public StudentPutRequest(
            string name,
            string email)
        {
            Name = name;
            Email = email;
        }
    }
}