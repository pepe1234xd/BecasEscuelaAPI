using BecasEscuela.Data;
using BecasEscuela.Models.Domain;
using BecasEscuela.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BecasEscuela.Repositories.Class
{
    public class BecaRepository : IBecasRepository
    {
        private readonly dbConnection dbConnection;

        public BecaRepository(dbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }
        public async Task<IEnumerable<Becas>> GetAllAsync()
        {
            var becas = await dbConnection.Becas.ToListAsync();
            return becas;
        }
    }
}
