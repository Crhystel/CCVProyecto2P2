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

        public bool EstudianteExiste(int id)
        {
            return _context.Estudiantes.Any(c=>c.Id== id);
        }

        public Estudiante GetEstudiante(int id)
        {
            return _context.Estudiantes.Where(c => c.Id == id).FirstOrDefault();
        }


        ICollection<Estudiante> IEstudiante.GetEstudiantes()
        {
            return _context.Estudiantes.OrderBy(c => c.Id).ToList();
        }
    }
}
