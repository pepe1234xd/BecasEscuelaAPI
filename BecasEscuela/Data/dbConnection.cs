using BecasEscuela.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BecasEscuela.Data
{
    public class dbConnection : DbContext
    {
        public dbConnection(DbContextOptions<dbConnection> options) : base(options){ }

        public DbSet<AlumnosBecados> AlumnosBecados { get; set; }
        public DbSet<Becas> Becas { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
