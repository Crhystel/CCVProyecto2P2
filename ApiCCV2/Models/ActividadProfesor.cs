using System.ComponentModel.DataAnnotations;

namespace ApiCCV2.Models
{
    public class ActividadProfesor
    {
        [Key]
        public int Id { get; set; }
        public int ProfesorId { get; set; }
        public Profesor Profesor { get; set; }
        public int ActividadId { get; set; }
        public Actividad Actividad { get; set; }
    }
}
