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

        public async Task<IEnumerable<StudentGetResponse>> GetAllAsync()
        {
            var students = await _studentsRepository.GetAllAsync();

            var studentsGetResponse = students.Select(x => new StudentGetResponse(x));

            return studentsGetResponse;
        }

        public async Task<Student> GetByAcademicRegistry(
            Guid academicRegistry)
        {
            return await _studentsRepository.GetByAcademicRegistry(academicRegistry);
        }

        public async Task<IEnumerable<Student>> GetByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            return await _studentsRepository.GetByNameAsync(name);
        }

        public async Task AddAsync(StudentPostRequest studentPostRequest)
        {
            var isCpfAlreadyRegistered = await _studentsRepository
                .IsCpfAlreadyRegistered(studentPostRequest.Cpf);

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
            string name,
            string email)
        {
            var student = await _studentsRepository.GetByAcademicRegistry(academicRegistry);

            if (student is null)
                throw new ArgumentNullException(nameof(student));

            student.Name = name;
            student.Email = email;

            await _studentsRepository.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid academicRegistry)
        {
            var student = await _studentsRepository.GetByAcademicRegistry(academicRegistry);

            if (student is null)
                throw new ArgumentNullException(nameof(student));

            _studentsRepository.Remove(student);

            await _studentsRepository.SaveChangesAsync();
        }
    }
}