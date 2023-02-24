using BecasEscuela.Models.Domain;

namespace BecasEscuela.Repositories.Interfaces
{
    public interface IAlumnoBecaRepository
    {
        Task<IEnumerable<AlumnosBecados>> GetAllAsync(int id);
    }
}
