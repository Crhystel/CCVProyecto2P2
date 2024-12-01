using ApiCCV2.Data;
using ApiCCV2.Interfaces;
using ApiCCV2.Models;

namespace ApiCCV2.Repositories
{
    
    public class ActividadEstudianteRepository : IActividadEstudiante
    {
        private readonly DataContext _context;
        public ActividadEstudianteRepository(DataContext context)
        {
            _context = context;
        }
        public bool ActividadEstudianteExiste(int aeid)
        {
            return _context.ActividadEstudiantes.Any(c=>c.Id == aeid);
        }

        public ActividadEstudiante GetActividadEstudiante(int aeId)
        {
            return _context.ActividadEstudiantes.Where(c=>c.Id == aeId).FirstOrDefault();
        }

        public ActividadEstudiante GetActividadEstudiantePorActividad(int actividadId)
        {
            return _context.ActividadEstudiantes.Where(c => c.ActividadId == actividadId).FirstOrDefault();
        }

        public ActividadEstudiante GetActividadEstudiantePorEstudiante(int estudianteId)
        {
            return _context.ActividadEstudiantes.Where(c => c.EstudianteId == estudianteId).FirstOrDefault();
        }

        public ICollection<ActividadEstudiante> GetActividadEstudiantes()
        {
            return _context.ActividadEstudiantes.OrderBy(c => c.Id).ToList();
        }
    }
}
