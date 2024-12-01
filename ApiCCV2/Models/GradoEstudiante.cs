using System.ComponentModel.DataAnnotations;

namespace ApiCCV2.Models
{
    public class GradoEstudiante
    {
        [Key]
        public int Id { get; set; }
        public int GradoId { get; set; }
        public Grado Grado { get; set; }
        public int EstudianteId { get; set; }   
        public Estudiante Estudiante { get; set; }
    }
}
