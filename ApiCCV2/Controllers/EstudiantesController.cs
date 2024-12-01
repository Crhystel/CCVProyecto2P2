using ApiCCV2.Dto;
using ApiCCV2.Interfaces;
using ApiCCV2.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiCCV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiantesController : Controller
    {
        private readonly IEstudiante _estudiante;
        private readonly IMapper _mapper;
        //Inyeccion de dependencias
        public EstudiantesController(IEstudiante estudiante, IMapper mapper)
        {
            _estudiante = estudiante;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Estudiante>))]
        public IActionResult GetEstudiantes()
        {
            var estudiantes = _mapper.Map<List<EstudianteDto>>(_estudiante.GetEstudiantes());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(estudiantes);

        }
        [HttpGet("{PorId}")]
        [ProducesResponseType(200, Type=typeof(Estudiante))]
        [ProducesResponseType(400)]
        public IActionResult GetEstudiante(int eId)
        {
            if (!_estudiante.EstudianteExiste(eId))
                return NotFound();
            var estudiante = _mapper.Map<EstudianteDto>(_estudiante.GetEstudiante(eId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(estudiante);
        }
        
    }
}
