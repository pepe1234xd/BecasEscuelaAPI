using BecasEscuela.Data;
using BecasEscuela.Models.Domain;
using BecasEscuela.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BecasEscuela.Repositories.Class
{
    public class AlumnoBecaRepository : IAlumnoBecaRepository
    {
        private readonly dbConnection dbConnection;

        public AlumnoBecaRepository(dbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public async Task<IEnumerable<AlumnosBecados>> GetAllAsync(int id)
        {
            var alumnosBecados = await dbConnection.AlumnosBecados
                .Include(ab => ab.Alumno)
                .Include(ab => ab.Beca)
                .Where(ab => ab.idAlumno == id)
                .ToListAsync();
            if(alumnosBecados == null)
            {
                return null;
            }

            return alumnosBecados;
        }
    }
}
