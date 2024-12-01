﻿using ApiCCV2.Models;
using System.ComponentModel.DataAnnotations;

namespace ApiCCV2.Dto
{
    public class EstudianteDto
    {
        //[Required(ErrorMessage = "Este campo es obligatorio.")]
        public GradoEnum Grado { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Cedula { get; set; }
    }
}
