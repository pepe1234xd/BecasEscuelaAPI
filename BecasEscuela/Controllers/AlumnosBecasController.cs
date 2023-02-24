using BecasEscuela.Models.Domain;
using BecasEscuela.Models.DTO;
using BecasEscuela.Repositories.Class;
using BecasEscuela.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BecasEscuela.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlumnosBecasController : ControllerBase
    {
        private readonly IAlumnoBecaRepository alumnoBecaRepository;

        public AlumnosBecasController(IAlumnoBecaRepository alumnoBecaRepository)
        {
            this.alumnoBecaRepository = alumnoBecaRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllStudentsBecas(int id)
        {          
            var becas = await alumnoBecaRepository.GetAllAsync(id);

            if(becas == null)
            {
                return NotFound();
            }
            return Ok(becas);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudentBecaAsync(AlumnosBecadosDTO alumnosBecados)
        {
            var alumno = new AlumnosBecados()
            {
                idAlumno = alumnosBecados.idAlumno,
                idBecas = alumnosBecados.idBecas
            };

            var studentBecado = await alumnoBecaRepository.AddAsync(alumno);

            return Ok(studentBecado);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteStudentBecaAsync(int id)
        {
            //get region form db
            var student = await alumnoBecaRepository.DeleteAsync(id);

            //if is null return not found
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

    }
}
