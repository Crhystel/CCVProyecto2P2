using CCVProyecto2P2.Models;
using CCVProyecto2P2.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCVProyecto2P2.Services.EstudianteService
{
    public interface IEstudiante
    {
        Task<bool> AddUpdateEstudianteAsync(Estudiante estudiante);
        Task<bool> DeleteEstudianteAsync(int estudianteId);
        Task<Estudiante>GetEstudianteAsync(int estudianteId);
        Task<IEnumerable<Estudiante>> GetEstudiantesAsync();
    }
}
