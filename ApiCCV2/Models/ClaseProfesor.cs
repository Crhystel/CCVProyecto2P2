using System.ComponentModel.DataAnnotations;

namespace ApiCCV2.Models
{
    public class ClaseProfesor
    {
        public int Id { get; set; }
        public int ClasePId { get; set; }
        public Clase ClaseP { get; set; }
        public int ProfesorId { get; set; }
        public Profesor Profesor { get; set; }
        public MateriaEnum Materia { get; set; }
    }
}
