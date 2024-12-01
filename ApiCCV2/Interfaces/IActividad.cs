using ApiCCV2.Models;

namespace ApiCCV2.Interfaces
{
    public interface IActividad
    {
        ICollection<Actividad> GetActividades();
        Actividad GetActividad(int actividadId);
        bool ActividadExiste(int actividadId);
    }
}
