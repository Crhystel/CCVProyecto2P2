using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCVProyecto2P2.Models
{
    public class Clase
    {
        public int Id { get; set; }

        public List<int> estudianteId { get; set; }
        public List<int> profesorId { get; set; }
        public List<int> actividadId { get; set; }
    }
}
