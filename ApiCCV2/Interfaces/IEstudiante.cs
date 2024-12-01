using ApiCCV2.Models;

namespace ApiCCV2.Interfaces
{
    public interface IEstudiante
    {
        ICollection<Estudiante> GetEstudiantes();
        Estudiante GetEstudiante(int id);
        Estudiante GetEstudiante(string nombre);
        bool EstudianteExiste(int id);    

    }
}
