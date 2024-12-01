using System.ComponentModel.DataAnnotations;

namespace ApiCCV2.Models
{
    public class ActividadEstudiante
    {
        [Key]
        public int Id { get; set; }
        public int EstudianteId { get; set; }
        public Estudiante Estudiante { get; set; }
        public int ActividadId { get; set; }
        public Actividad Actividad { get; set; }
    }
}
