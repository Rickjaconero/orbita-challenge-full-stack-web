using Microsoft.AspNetCore.Mvc;
using StudentsAPI.Data.Abstractions.Repositories;
using StudentsAPI.Domain.Entities;

namespace StudenstAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : Controller
    {
        private readonly IStudentsRepository _studentsRepository;

        public StudentsController(IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }

        [HttpGet]
        [Route("name")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var students = await _studentsRepository.GetAllAsync();

                var student = await _studentsRepository.GetByNameAsync("lice");

                var guidStudent = await _studentsRepository.GetByAcademicRegistry(new Guid("f409eb32-d85f-416d-afdc-2dc6b5754d85"));

                if (guidStudent is not null)
                    await _studentsRepository.RemoveAsync(guidStudent);

                var newStudent = new Student(
                    new Guid(),
                    "Bruna Santos",
                    "bruna.santos@example.com",
                    "11111111111");

                await _studentsRepository.AddAsync(newStudent);

                await _studentsRepository.SaveChangesAsync();

                return Ok(student);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}