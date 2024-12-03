using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCVProyecto2P2.Models
{
    public class Estudiante : Usuario
    {

        public GradoEnum Grado { get; set; }

        public List<int> claseId { get; set; }
        public List<int> actividadId { get; set; }

    }
}
