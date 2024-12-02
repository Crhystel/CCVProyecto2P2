using ApiCCV2.Models;

namespace ApiCCV2.Dto
{
    public class ProfesorDto
    {
        public int Id { get; set; }
        public MateriaEnum Materias { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Cedula { get; set; }

    }
}
