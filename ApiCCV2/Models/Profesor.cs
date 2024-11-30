using System.ComponentModel.DataAnnotations;

namespace ApiCCV2.Models
{
    public class Profesor : Usuario
    {
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public Materia Materias { get; set; }
        public ICollection<ClaseProfesor> ClaseProfesores { get; set; }
        public ICollection<ActividadProfesor> ActividadProfesores { get; set; }
    }
}
