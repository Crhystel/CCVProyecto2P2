using ApiCCV2.Data;
using ApiCCV2.Interfaces;
using ApiCCV2.Models;

namespace ApiCCV2.Repositories
{
    public class ProfesorRepository : IProfesor
    {
        private readonly DataContext _context;
        public ProfesorRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateProfesor(int claseId, int actividadId, int materiaId, Profesor profesor)
        {
            var claseProfesor = _context.Clases.Where(c => c.Id == claseId).FirstOrDefault();
            var materiaProfesor = _context.Materias.Where(c => c.Id == materiaId).FirstOrDefault();
            var actividadProfesor = _context.Actividades.Where(c => c.Id == actividadId).FirstOrDefault();
            var claseProfesorNuevo = new ClaseProfesor()
            {
                ClaseP = claseProfesor,
                Profesor = profesor,

            };
            _context.Add(claseProfesorNuevo);
            var materiaProfesorNuevo = new MateriaProfesor()
            {
                Materia= materiaProfesor,
                Profesor= profesor,
            };
            _context.Add(materiaProfesorNuevo);
            var actividadProfesorNuevo = new ActividadProfesor()
            {
                Actividad = actividadProfesor,
                Profesor=profesor,
            };
            _context.Add(actividadProfesorNuevo);
            _context.Add(profesor);
            return Save();
        }

        public bool DeleteProfesor(int claseId, int actividadId, int materiaId, Profesor profesor)
        {
            _context.Remove(profesor);
            return Save();
        }

        public Profesor GetProfesor(int id)
        {
            return _context.Profesores.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<Profesor> GetProfesores()
        {
            return _context.Profesores.OrderBy(c => c.Nombre).ToList();
        }

        public bool ProfesorExiste(int id)
        {
            return _context.Profesores.Any(c => c.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateProfesor(int claseId, int actividadId, int materiaId, Profesor profesor)
        {
            _context.Update(profesor);
            return Save();
        }
    }
}
