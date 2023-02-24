using System.ComponentModel.DataAnnotations;

namespace BecasEscuela.Models.DTO
{
    public class AddStudentDTO
    {
        [MaxLength(50)]
        public string name { get; set; }
        public bool gender { get; set; }
        public int age { get; set; }

    }
}
