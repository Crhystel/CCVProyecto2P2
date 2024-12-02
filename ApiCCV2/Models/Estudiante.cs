using System.ComponentModel.DataAnnotations;

namespace ApiCCV2.Models
{
    public class Estudiante : Usuario
    {
         
        public GradoEnum Grado { get; set; }
       
        public ICollection<ClaseProfesor> ClaseEstudiantes { get; set; }
        public ICollection<ActividadEstudiante> ActividadEstudiantes { get; set; }
        
    }
}
