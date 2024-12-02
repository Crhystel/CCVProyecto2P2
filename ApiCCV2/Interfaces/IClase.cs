using ApiCCV2.Models;

namespace ApiCCV2.Interfaces
{
    public interface IClase
    {
        ICollection<Clase> GetClases();
        Clase GetClase(int id);
        bool ClaseExiste(int id);
        bool CreateClase( int claseId,int estudiantesId, int profesoresId, Clase clase);
        bool UpdateClase(int claseId,int estudiantesId, int profesoresId, Clase clase);
        bool DeleteClase(Clase clase);

        bool Save();
    }
}
