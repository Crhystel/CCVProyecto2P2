using ApiCCV2.Data;
using ApiCCV2.Interfaces;
using ApiCCV2.Models;

namespace ApiCCV2.Repositories
{
    public class EstudianteRepository : IEstudiante
    {
        private readonly DataContext _context;
        public EstudianteRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateEstudiante(int claseId, int gradoId,int actividadId, Estudiante estudiante)
        {
            var claseEstudiante= _context.Clases.Where(c=>c.Id ==claseId).FirstOrDefault();
            var gradoEstudiante=_context.Grados.Where(c=>c.Id==gradoId).FirstOrDefault();
            var actividadEstudiante = _context.Actividades.Where(c => c.Id == actividadId).FirstOrDefault();
            var claseEstudianteNuevo = new ClaseEstudiante()
            {
                Clase = claseEstudiante,
                Estudiante= estudiante,

            };
            _context.Add(claseEstudianteNuevo);
            var gradoEstudianteNuevo = new GradoEstudiante()
            {
                Grado = gradoEstudiante,
                Estudiante = estudiante,
            };
            _context.Add(gradoEstudianteNuevo);
            var actividadEstudianteNuevo = new ActividadEstudiante()
            {
                Actividad = actividadEstudiante,
                Estudiante = estudiante,
            };
            _context.Add(actividadEstudianteNuevo);
            _context.Add(estudiante);
            return Save();
        }

        public bool DeleteEstudiante(int claseId, int gradoId, int actividadId, Estudiante estudiante)
        {
            _context.Remove(estudiante);
            return Save();
        }

        public bool EstudianteExiste(int id)
        {
            return _context.Estudiantes.Any(c=>c.Id== id);
        }

        public Estudiante GetEstudiante(int id)
        {
            return _context.Estudiantes.Where(c => c.Id == id).FirstOrDefault();
        }

        public bool Save()
        {
            var saved= _context.SaveChanges();
            return saved > 0 ?true : false;
        }

        public bool UpdateEstudiante(int claseId, int gradoId, int actividadId, Estudiante estudiante)
        {
            _context.Update(estudiante);
            return Save();
        }

        ICollection<Estudiante> IEstudiante.GetEstudiantes()
        {
            return _context.Estudiantes.OrderBy(c => c.Id).ToList();
        }
    }
}
