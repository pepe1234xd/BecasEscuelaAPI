using System.ComponentModel.DataAnnotations.Schema;

namespace BecasEscuela.Models.Domain
{
    public class AlumnosBecados
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int idAlumno { get; set; }
        [ForeignKey("idAlumno")] 
        public Student Alumno { get; set; } 

        public int idBecas { get; set; }
        [ForeignKey("idBecas")]
        public Becas Beca { get; set; } 
    }
}
