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

        public Clase GetClase(int id)
        {
            return _context.Clases.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<Clase> GetClases()
        {
            return _context.Clases.OrderBy(c => c.Id).ToList();
        }
    }
}
