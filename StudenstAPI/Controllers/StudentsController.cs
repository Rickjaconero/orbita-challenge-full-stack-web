using Microsoft.AspNetCore.Mvc;
using StudentsAPI.Application.Abstractions.Services;
using StudentsAPI.Domain.DTOs.Requests;

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
        public async Task<IActionResult> GetAsync([FromQuery] string name)
        {
            try
            {
                var students = string.IsNullOrEmpty(name) ?
                    await _studentsService.GetAsync() :
                    await _studentsService.GetByNameAsync(name);

                return Ok(students);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("{academicRegistry}")]
        public async Task<IActionResult> GetByAcademicRegistry([FromRoute] Guid academicRegistry)
        {
            try
            {
                var students = await _studentsService.GetByAcademicRegistryAsync(academicRegistry);

                return Ok(students);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> PostAsync([FromBody] StudentPostRequest postRequest)
        {
            try
            {
                await _studentsService.AddAsync(postRequest);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("{academicRegistry}")]
        public async Task<IActionResult> PutAsync(
            [FromBody] StudentPutRequest putRequest,
            [FromRoute] Guid academicRegistry)
        {
            try
            {
                await _studentsService.EditAsync(
                    academicRegistry,
                    putRequest);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{academicRegistry}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid academicRegistry)
        {
            try
            {
                await _studentsService.RemoveAsync(academicRegistry);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}