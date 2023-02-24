using BecasEscuela.Models.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace BecasEscuela.Models.DTO
{
    public class AlumnosBecadosDTO
    {
        public int id { get; set; }
        public int idAlumno { get; set; }
        public int idBecas { get; set; }
    }
}
