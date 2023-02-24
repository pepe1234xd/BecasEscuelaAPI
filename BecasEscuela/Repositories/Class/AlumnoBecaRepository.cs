using BecasEscuela.Data;
using BecasEscuela.Models.Domain;
using BecasEscuela.Models.DTO;
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

        public async Task<AlumnosBecados> AddAsync(AlumnosBecados alumnosBecados)
        {

            var addedStudent = await dbConnection.AlumnosBecados.AddAsync(alumnosBecados);
            await dbConnection.SaveChangesAsync();

            // Devolver el estudiante agregado
            return addedStudent.Entity;
        }

        public async Task<AlumnosBecados> DeleteAsync(int id)
        {
            var alumnoBecado = await dbConnection.AlumnosBecados.FindAsync(id);
            if (alumnoBecado == null)
            {
                return null;
            }

            dbConnection.AlumnosBecados.Remove(alumnoBecado);
            await dbConnection.SaveChangesAsync();

            return alumnoBecado;
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

        public async Task<AlumnosBecados> GetAsync(int id)
        {
            var student = await dbConnection.AlumnosBecados.FindAsync(id);
            return student;
        }
    }
}
