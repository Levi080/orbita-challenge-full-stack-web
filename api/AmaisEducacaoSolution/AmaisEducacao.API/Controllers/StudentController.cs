using AmaisEducacao.API.Services.Interfaces;
using AmaisEducacao.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace AmaisEducacao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("GetStudentsList")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentsList()
        {
            try
            {
                var students = await _studentService.GetAllStudentsAsync();
                return Ok(students);
            }
            catch (Exception ex) { 
                return StatusCode(500, "Internal Server Error. Please contact support.");
            }

        }


        [HttpGet("GetStudentsByNameAsync")]
        public async Task<ActionResult<Student>> GetStudentsByNameAsync([FromQuery] string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                    return BadRequest("O parâmetro 'name' é obrigatório para esta busca.");
                
                var students = await _studentService.GetStudentsByNameAsync(name);
                return Ok(students);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error. Please contact support.");
            }
        }


        [HttpPost("CreateStudent")]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                
                var createdStudent = await _studentService.CreateStudentAsync(student);

                if (createdStudent == null)
                    return BadRequest("Registration number or CPF already exists.");

                return Ok(createdStudent);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error. Please contact support.");
            }
        }


        [HttpPut("UpdateStudent")]
        public async Task<IActionResult> UpdateStudent(Student student)
        {
            try
            {
                var updatedStudent = await _studentService.UpdateStudentAsync(student);

                if (updatedStudent == null)
                    return BadRequest("Registration number or CPF not found.");

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error. Please contact support.");
            }
        }


        [HttpDelete("DeleteStudent")]
        public async Task<IActionResult> DeleteStudent([FromQuery] string ra)
        {
            try
            {
                var result = await _studentService.DeleteStudentAsync(ra);

                if (!result)
                    return BadRequest("Registration number or CPF not found.");

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error. Please contact support.");
            }
        }

    }
}
