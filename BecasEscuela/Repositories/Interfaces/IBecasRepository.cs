using BecasEscuela.Models.Domain;

namespace BecasEscuela.Repositories.Interfaces
{
    public interface IBecasRepository
    {
        Task<IEnumerable<Becas>> GetAllAsync();
    }
}
