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
      [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult CrearEstudiante([FromQuery] int claseId, [FromQuery] int gradoId, [FromQuery] int actividadId, [FromBody] EstudianteDto estudianteCreate)
        {
            if (estudianteCreate == null)
                return BadRequest(ModelState);
            var estudiantes = _estudiante.GetEstudiantes()
                .Where(c => c.Nombre  == estudianteCreate.Nombre ).FirstOrDefault();
            if(estudiantes != null)
            {
                ModelState.AddModelError("", "Estudiante ya existe");
                return StatusCode(422, ModelState);
            }
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var estudianteMap = _mapper.Map<Estudiante>(estudianteCreate);
            if(!_estudiante.CreateEstudiante(claseId, gradoId, actividadId,estudianteMap))
            {
                ModelState.AddModelError("", "Algo salio mal");
                return StatusCode(500,ModelState);
            }
            return Ok("gucci");
        }  
    }
    
}
