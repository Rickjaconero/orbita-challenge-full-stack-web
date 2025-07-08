using Microsoft.AspNetCore.Mvc;
using StudentsAPI.Data.Abstractions.Repositories;

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
        public IActionResult Get()
        {
            try
            {
                var veiculo = _studentsRepository.GetByName("Alice Santos");

                return Ok(veiculo);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}