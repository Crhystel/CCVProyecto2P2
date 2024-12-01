using ApiCCV2.Models;

namespace ApiCCV2.Interfaces
{
    public interface IProfesor
    {
        ICollection<Profesor> GetProfesores();
        Profesor GetProfesor(int id);
       
        bool ProfesorExiste(int id);

    }
}
