using System.ComponentModel.DataAnnotations;

namespace ApiCCV2.Models
{
    public class Clase
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [Display(Name = "Clase")]
        public Materia Materia { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public Grado Grado { get; set; }
        public ICollection<ClaseEstudiante> ClaseEstudiantes { get; set; }
        public ICollection<ClaseProfesor> ClaseProfesores { get; set; }
        public ICollection<ClaseActividad> ClaseActividades { get; set; }
    }
}
