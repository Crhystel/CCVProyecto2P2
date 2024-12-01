﻿using ApiCCV2.Models;

namespace ApiCCV2.Dto
{
    public class ClaseDto
    {
        public ICollection<ClaseEstudiante> ClaseEstudiantes { get; set; }
        public ICollection<ClaseProfesor> ClaseProfesores { get; set; }
        public ICollection<ClaseActividad> ClaseActividades { get; set; }
    }
}