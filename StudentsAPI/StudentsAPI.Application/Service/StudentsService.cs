using StudentsAPI.Application.Abstractions.Services;
using StudentsAPI.Data.Abstractions.Repositories;
using StudentsAPI.Domain.DTOs.Requests;
using StudentsAPI.Domain.DTOs.Responses;
using StudentsAPI.Domain.Entities;

namespace StudentsAPI.Service.Service
{
    internal sealed class StudentsService : IStudentsService
    {
        private readonly IStudentsRepository _studentsRepository;

        public StudentsService(IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }

        public async Task<IEnumerable<StudentGetResponse>> GetAsync()
        {
            var students = await _studentsRepository.GetAsync();

            var studentsGetResponse = students.Select(x => new StudentGetResponse(x));

            return studentsGetResponse;
        }

        public async Task<StudentGetResponse> GetByAcademicRegistryAsync(
            Guid academicRegistry)
        {
            var student = await _studentsRepository
                .GetByAcademicRegistryAsync(academicRegistry);

            var studentGetResponse = new StudentGetResponse(student);

            return studentGetResponse;
        }

        public async Task<IEnumerable<StudentGetResponse>> GetByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            var students = await _studentsRepository.GetByNameAsync(name);

            var studentsGetResponse = students.Select(x => new StudentGetResponse(x));

            return studentsGetResponse;
        }

        public async Task AddAsync(StudentPostRequest studentPostRequest)
        {
            var isCpfAlreadyRegistered = await _studentsRepository
                .IsCpfAlreadyRegisteredAsync(studentPostRequest.Cpf);

            if (isCpfAlreadyRegistered)
                throw new ArgumentException(nameof(studentPostRequest.Cpf));

            var student = new Student(
                new Guid(),
                studentPostRequest.Name,
                studentPostRequest.Email,
                studentPostRequest.Cpf);

            await _studentsRepository.AddAsync(student);

            await _studentsRepository.SaveChangesAsync();
        }

        public async Task EditAsync(
            Guid academicRegistry,
            StudentPutRequest studentPutRequest)
        {
            var student = await _studentsRepository.GetByAcademicRegistryAsync(academicRegistry);

            if (student is null)
                throw new ArgumentNullException(nameof(student));

            student.Name = studentPutRequest.Name;
            student.Email = studentPutRequest.Email;

            await _studentsRepository.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid academicRegistry)
        {
            var student = await _studentsRepository.GetByAcademicRegistryAsync(academicRegistry);

            if (student is null)
                throw new ArgumentNullException(nameof(student));

            _studentsRepository.Remove(student);

            await _studentsRepository.SaveChangesAsync();
        }
    }
}