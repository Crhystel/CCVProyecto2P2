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
    }
}
