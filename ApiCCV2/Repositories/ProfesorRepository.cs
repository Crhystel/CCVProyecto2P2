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

        public bool CreateProfesor( MateriaEnum materiaId, Profesor profesor)
        { 
            
            _context.Add(profesor);
            return Save();
        }

        public bool DeleteProfesor( Profesor profesor)
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

        public bool UpdateProfesor(MateriaEnum materiaId, Profesor profesor)
        {
            _context.Update(profesor);
            return Save();
        }
    }
}
