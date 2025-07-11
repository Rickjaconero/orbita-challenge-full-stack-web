using StudentsAPI.Domain.DTOs.Requests;
using StudentsAPI.Domain.DTOs.Responses;

namespace StudentsAPI.Application.Abstractions.Services
{
    public interface IStudentsService
    {
        Task<IEnumerable<StudentGetResponse>> GetAsync();
        Task<StudentGetResponse> GetByAcademicRegistryAsync(Guid academicRegistry);
        Task<IEnumerable<StudentGetResponse>> GetByNameAsync(string name);
        Task AddAsync(StudentPostRequest studentPostRequest);
        Task EditAsync(Guid academicRegistry, StudentPutRequest studentPutRequest);
        Task RemoveAsync(Guid academicRegistry);
    }
}