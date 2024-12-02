using ApiCCV2.Models;

namespace ApiCCV2.Interfaces
{
    public interface IProfesor
    {
        ICollection<Profesor> GetProfesores();
        Profesor GetProfesor(int id);
       bool CreateProfesor(int materiaId, Profesor profesor);
        bool UpdateProfesor(int materiaId, Profesor profesor);
        bool DeleteProfesor(Profesor profesor);
        bool ProfesorExiste(int id);
        bool Save();
    }
}
