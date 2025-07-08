using Microsoft.AspNetCore.Mvc;
using StudentsAPI.Application.Abstractions.Services;

namespace StudenstAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : Controller
    {
        private readonly IStudentsService _studentsService;

        public StudentsController(IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var students = await _studentsService.GetAllAsync();

                return Ok(students);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}