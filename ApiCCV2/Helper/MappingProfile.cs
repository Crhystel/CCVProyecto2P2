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
            CreateMap<EstudianteDto, Estudiante>();
            CreateMap<Profesor, ClaseDto>();
            CreateMap<ClaseDto, Profesor>();
            CreateMap<Clase, ClaseDto>();
            CreateMap<ClaseDto, Clase>();
            CreateMap<Actividad, ActividadDto>();
            CreateMap<ActividadDto, Actividad>();
            CreateMap<ActividadProfesor, ActividadProfesorDto>();
            CreateMap<ActividadProfesorDto, ActividadProfesor>();
            
        }
    }
}
