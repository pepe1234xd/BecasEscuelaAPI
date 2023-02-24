using BecasEscuela.Repositories.Class;
using BecasEscuela.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BecasEscuela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosBecasController : ControllerBase
    {
        private readonly IAlumnoBecaRepository alumnoBecaRepository;

        public AlumnosBecasController(IAlumnoBecaRepository alumnoBecaRepository)
        {
            this.alumnoBecaRepository = alumnoBecaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents(int id)
        {          
            var students = await alumnoBecaRepository.GetAllAsync(id);

            if(students == null)
            {
                return NotFound();
            }

            return Ok(students);
        }
    }
}
