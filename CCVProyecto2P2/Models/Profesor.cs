using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCVProyecto2P2.Models
{
    public class Profesor : Usuario
    {
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public MateriaEnum? Materia { get; set; }
    }
}
