using ApiCCV2.Dto;
using ApiCCV2.Models;
using AutoMapper;

namespace ApiCCV2.Helper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Estudiante, EstudianteDto>();
            CreateMap<Profesor, ProfesorDto>();
            CreateMap<Clase, ClaseDto>();
            CreateMap<Actividad, ActividadDto>();
        }
    }
}
