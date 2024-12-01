using System.ComponentModel.DataAnnotations;

namespace ApiCCV2.Models
{
    public class MateriaProfesor
    {
        [Key]
        public int Id { get; set; }
        public int ProfesorId { get; set; }
        public Profesor Profesor { get; set; }
        public int MateriaId { get; set; }
        public Materia Materia { get; set; }
    }
}
