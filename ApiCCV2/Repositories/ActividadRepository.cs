using ApiCCV2.Data;
using ApiCCV2.Interfaces;
using ApiCCV2.Models;

namespace ApiCCV2.Repositories
{
    public class ActividadRepository : IActividad
    {
        public readonly DataContext _context;
        public ActividadRepository(DataContext context)
        {
            _context = context;
        }
        public bool ActividadExiste(int actividadId)
        {
           return _context.Actividades.Any(c=>c.Id== actividadId);
        }

        public Actividad GetActividad(int actividadId)
        {
            return _context.Actividades.Where(c => c.Id == actividadId).FirstOrDefault();
        }

        public ICollection<Actividad> GetActividades()
        {
            return _context.Actividades.OrderBy(c=>c.Id).ToList();
        }
    }
}
