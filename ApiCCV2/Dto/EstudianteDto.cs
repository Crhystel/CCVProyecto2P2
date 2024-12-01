using ApiCCV2.Models;
using System.ComponentModel.DataAnnotations;

namespace ApiCCV2.Dto
{
    public class EstudianteDto
    {
        //[Required(ErrorMessage = "Este campo es obligatorio.")]
        public GradoEnum Grado { get; set; }
    }
}
