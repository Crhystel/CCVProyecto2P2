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
        //public ICollection<Estudiante> GetEstudiantes()
        //{
        //    return _context.Estudiantes.OrderBy(c => c.Id).ToList();
        //}

        ICollection<Estudiante> IEstudiante.GetEstudiantes()
        {
            return _context.Estudiantes.OrderBy(c => c.Id).ToList();
        }
    }
}
