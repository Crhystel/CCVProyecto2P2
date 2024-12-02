using ApiCCV2.Models;
using System.ComponentModel.DataAnnotations;

namespace ApiCCV2.Dto
{
    public class EstudianteDto
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Este campo es obligatorio.")]
        public GradoEnum Grado { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Cedula { get; set; }
        public string Contrasenia { get; set; }
        public string NombreUsuario { get; set; }


    }
}
