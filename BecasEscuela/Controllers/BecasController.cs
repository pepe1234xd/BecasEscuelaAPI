using BecasEscuela.Repositories.Class;
using BecasEscuela.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BecasEscuela.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BecasController : ControllerBase
    {
        private readonly IBecasRepository becasRepository;

        public BecasController(IBecasRepository becasRepository)
        {     
            this.becasRepository = becasRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await becasRepository.GetAllAsync();
            return Ok(students);
        }
    }
}
