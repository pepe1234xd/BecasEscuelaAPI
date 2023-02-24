using BecasEscuela.Models.Domain;
using BecasEscuela.Models.DTO;
using BecasEscuela.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BecasEscuela.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await studentRepository.GetAllAsync();
            return Ok(students);
        }


        [HttpGet]
        [Route("{id}")]
        [ActionName("GetStudentAsync")]
        public async Task<IActionResult> GetStudentAsync(int id)
        {
            var student = await studentRepository.GetAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudentAsync(Models.DTO.AddStudentDTO addStudent)
        {
            
            var student = new Student()
            {
                name = addStudent.name,
                age= addStudent.age,
                gender= addStudent.gender
            };

            student = await studentRepository.AddAsync(student);

            return CreatedAtAction(nameof(GetStudentAsync),new { id = student.id }, student);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteStudentAsync(int id)
        {
            //get region form db
            var student = await studentRepository.DeleteAsync(id);

            //if is null return not found
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateRegionAsync(int id, [FromBody] UpdateStudentDTO updateStudentDTO)
        {
            var student = new Student
            {
                name = updateStudentDTO.name, 
                age = updateStudentDTO.age, 
                gender= updateStudentDTO.gender
            };

            student = await studentRepository.UpdateAsync(id, student);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

    }
}
