using BecasEscuela.Models.Domain;

namespace BecasEscuela.Repositories.Interfaces
{
    public interface IAlumnoBecaRepository
    {
        Task<AlumnosBecados> GetAsync(int id);
        Task<IEnumerable<AlumnosBecados>> GetAllAsync(int id);
        Task<AlumnosBecados> AddAsync(AlumnosBecados alumnosBecados);
        Task<AlumnosBecados> DeleteAsync(int id);
    }
}
