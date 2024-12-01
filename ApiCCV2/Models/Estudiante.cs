using System.ComponentModel.DataAnnotations;

namespace ApiCCV2.Models
{
    public class Estudiante : Usuario
    {
       
        public ICollection<ClaseEstudiante> ClaseEstudiantes { get; set; }
        public ICollection<ActividadEstudiante> ActividadEstudiantes { get; set; }
        public ICollection<GradoEstudiante> GradoEstudiantes { get; set; }
    }
}
