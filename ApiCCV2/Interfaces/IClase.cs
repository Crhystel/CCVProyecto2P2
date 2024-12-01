using ApiCCV2.Models;

namespace ApiCCV2.Interfaces
{
    public interface IClase
    {
        ICollection<Clase> GetClases();
        Clase GetClase(int id);
       
        bool ClaseExiste(int id);

    }
}
