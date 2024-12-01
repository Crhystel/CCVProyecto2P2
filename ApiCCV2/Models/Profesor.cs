using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCCV2.Models
{
    public class Profesor : Usuario
    {
        [ForeignKey(nameof(Materia))]
        public int MateriaId { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public MateriaEnum Materias { get; set; }

        public ICollection<ClaseProfesor> ClaseProfesores { get; set; }
        public ICollection<ActividadProfesor> ActividadProfesores { get; set; }
        public ICollection<MateriaProfesor>MateriaProfesores { get; set; }
    }
}
