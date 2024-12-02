using System.ComponentModel.DataAnnotations;

namespace ApiCCV2.Models
{
    public class ClaseEstudiante
    {
        [Key]
        public int Id { get; set; }
        public int ClaseId { get; set; }


        public Clase Clase { get; set; }

        public int EstudianteId { get; set; }

        public Estudiante Estudiante { get; set; }
        [Required]
        public GradoEnum Grado { get; set; }
    }
}
