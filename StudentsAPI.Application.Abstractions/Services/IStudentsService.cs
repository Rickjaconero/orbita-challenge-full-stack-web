using StudentsAPI.Domain.DTOs.Requests;
using StudentsAPI.Domain.DTOs.Responses;
using StudentsAPI.Domain.Entities;

namespace StudentsAPI.Application.Abstractions.Services
{
    public interface IStudentsService
    {
        Task<IEnumerable<StudentGetResponse>> GetAllAsync();
        Task<Student> GetByAcademicRegistry(Guid academicRegistry);
        Task<IEnumerable<Student>> GetByNameAsync(string name);
        Task AddAsync(StudentPostRequest studentPostRequest);
        Task EditAsync(Guid academicRegistry,string name,string email);
        Task RemoveAsync(Guid academicRegistry);
    }
}