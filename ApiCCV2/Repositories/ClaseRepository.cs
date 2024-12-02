using ApiCCV2.Data;
using ApiCCV2.Interfaces;
using ApiCCV2.Models;

namespace ApiCCV2.Repositories
{
    public class ClaseRepository : IClase
    {
        private readonly DataContext _context;
        public ClaseRepository(DataContext context)
        {
            _context = context;
        }
        public bool ClaseExiste(int id)
        {
            return _context.Clases.Any(c => c.Id == id);
        }

        public bool CreateClase(int claseId, int estudiantesId, int profesoresId, Clase clase)
        {
            var claseClase=_context.Clases.SingleOrDefault(c => c.Id == claseId);
            var estudianteClase = _context.Estudiantes.SingleOrDefault(e => e.Id == estudiantesId);
            var profesorClase=_context.Profesores.SingleOrDefault(p => p.Id == profesoresId);

            var nuevoProfesorClase = new ClaseProfesor()
            {
                ClaseP = claseClase,
                Profesor = profesorClase,
            };
            _context.Add(nuevoProfesorClase);
            var nuevoEstudianteClase = new ClaseEstudiante()
            {
                Clase = claseClase,
                Estudiante= estudianteClase
            };
            _context.Add(nuevoEstudianteClase);

            return Save();
        }

       

        public bool DeleteClase( Clase clase)
        {
            _context.Remove(clase);
            return Save();
        }

        public Clase GetClase(int id)
        {
            return _context.Clases.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<Clase> GetClases()
        {
            return _context.Clases.OrderBy(c => c.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateClase(int claseId,int estudiantesId, int profesoresId, Clase clase)
        {
            _context.Update(clase);
            return Save();
        }
    }
}
