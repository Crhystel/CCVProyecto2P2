using ApiCCV2.Models;

namespace ApiCCV2.Interfaces
{
    public interface IActividadProfesor
    {
        ICollection<ActividadProfesor> GetActividadProfesores();
        ActividadProfesor GetActividadProfesor(int apId);
        ActividadProfesor GetActividadProfesorPorProfesor(int pId);
        ActividadProfesor GetActividadProfesorPorActividad(int aId);
        bool ActividadProfesorExiste(int aeId);
        //bool CreateActividad(Actividad actividad);
    }
}
