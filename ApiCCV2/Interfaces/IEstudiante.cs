using ApiCCV2.Models;

namespace ApiCCV2.Interfaces
{
    public interface IEstudiante
    {
        ICollection<Estudiante> GetEstudiantes();
    }
}
