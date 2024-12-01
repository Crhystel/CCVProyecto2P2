using ApiCCV2.Data;
using ApiCCV2.Interfaces;
using AutoMapper;

namespace ApiCCV2.Repositories
{
    public class ActividadProfesorRepository : IActividadProfesor
    {
        private readonly DataContext _context;
        public ActividadProfesorRepository(DataContext context)
        {
            _context = context;
        }
        public Models.ActividadProfesor GetActividadProfesor(int apId)
        {
            return _context.ActividadProfesores.Where(c=>c.Id == apId).FirstOrDefault();
        }

        public ICollection<Models.ActividadProfesor> GetActividadProfesores()
        {
            return _context.ActividadProfesores.OrderBy(c=>c.Id).ToList();
        }

        public Models.ActividadProfesor GetActividadProfesorPorActividad(int aId)
        {
            return _context.ActividadProfesores.Where(c => c.ActividadId == aId).FirstOrDefault();
        }

        public Models.ActividadProfesor GetActividadProfesorPorProfesor(int pId)
        {
            return _context.ActividadProfesores.Where(c => c.ProfesorId == pId).FirstOrDefault();
        }

        public bool ActividadProfesorExiste(int aeId)
        {
            return _context.ActividadProfesores.Any(c => c.Id == aeId);
        }
    }
}
