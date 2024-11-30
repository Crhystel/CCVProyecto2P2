using System.ComponentModel.DataAnnotations;

namespace ApiCCV2.Models
{
    public class ClaseActividad
    {
        [Key]
        public int Id { get; set; }
        public int ClaseId { get; set; }
        public Clase Clase { get; set; }
        public int ActividadId { get; set; }
        public Actividad Actividad { get; set; }
    }
}
