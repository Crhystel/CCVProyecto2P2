
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

        public bool CreateEstudiante(GradoEnum gradoId, Estudiante estudiante)
        {
            estudiante.Grado = gradoId;
            _context.Add(estudiante);
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

        public bool UpdateEstudiante( GradoEnum gradoId,Estudiante estudiante)
        {
            _context.Update(estudiante);
            return Save();
        }

        public ICollection<Estudiante> GetEstudiantes()
        {
            return _context.Estudiantes.OrderBy(c => c.Id).ToList();
        }

        public bool DeleteEstudiante(Estudiante estudiante)
        {
            _context.Remove(estudiante);
            return Save();
        }
    }
}
