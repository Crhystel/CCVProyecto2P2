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
        Task<bool> AddUpdateEstudianteAsync(EstudianteViewModel)
    }
}
