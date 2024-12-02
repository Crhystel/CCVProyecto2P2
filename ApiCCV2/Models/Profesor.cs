using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCCV2.Models
{
    public class Profesor : Usuario
    {
        public MateriaEnum Materia { get; set; }
        public ICollection<ClaseProfesor> ClaseProfesores { get; set; }
        public ICollection<ActividadProfesor> ActividadProfesores { get; set; }
    }
}
