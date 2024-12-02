using ApiCCV2.Models;

namespace ApiCCV2.Interfaces
{
    public interface IActividad
    {
        ICollection<Actividad> GetActividades();
        Actividad GetActividad(int actividadId);
        bool ActividadExiste(int actividadId);
        bool CreateActividad(int actividadId, int claseId, Actividad actividad);
        bool UpdateActividad(int actividadId, int claseId, Actividad actividad);
        bool DeleteActividad(Actividad actividad);
        bool Save();
    }
}
