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
            var claseClase=_context.Clases.Where(c=>c.Id==claseId).FirstOrDefault();
            var estudianteClase = _context.Estudiantes.Where(c => c.Id == estudiantesId).FirstOrDefault();
            var profesorClase=_context.Profesores.Where(c=>c.Id == profesoresId).FirstOrDefault();

            var nuevoProfesorClase = new ClaseProfesor()
            {
                ClaseP = claseClase,
                Profesor = profesorClase,
            };
            _context.Add(nuevoProfesorClase);
            return Save();
        }

        public bool DeleteClase(Clase clase)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public bool UpdateClase(int claseId,int estudiantesId, int profesoresId, Clase clase)
        {
            throw new NotImplementedException();
        }
    }
}
