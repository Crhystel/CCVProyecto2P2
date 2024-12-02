using ApiCCV2.Models;

namespace ApiCCV2.Dto
{
    public class ClaseDto
    {
        public int Id { get; set; }
        public List<int> ClaseEstudiantes { get; set; }
        public List<int> ClaseProfesores { get; set; }
       
    }
}
