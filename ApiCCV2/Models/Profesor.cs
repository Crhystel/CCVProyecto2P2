using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCCV2.Models
{
    public class Profesor : Usuario
    {
       
        public ICollection<ClaseProfesor> ClaseProfesores { get; set; }
        public ICollection<ActividadProfesor> ActividadProfesores { get; set; }
        public ICollection<MateriaProfesor>MateriaProfesores { get; set; }
    }
}
