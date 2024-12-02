using ApiCCV2.Models;

namespace ApiCCV2.Interfaces
{
    public interface IEstudiante
    {

        ICollection<Estudiante> GetEstudiantes();
        Estudiante GetEstudiante(int id);
        bool EstudianteExiste(int id);
        bool DeleteEstudiante( Estudiante estudiante);
        bool Save();
        bool CreateEstudiante(GradoEnum gradoId,Estudiante estudiante);
        bool UpdateEstudiante(GradoEnum gradoId,  Estudiante estudiante);
    }
}