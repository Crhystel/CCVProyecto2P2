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
        private readonly IActividadEstudiante _actividadEstudiante;
        //Inyeccion de dependencias
        public EstudiantesController(IEstudiante estudiante, 
            /*IClaseEstudiante _claseEstudiante*/IActividadEstudiante actividadEstudiante, IMapper mapper)
        {
            _estudiante = estudiante;
            _mapper = mapper;
            _actividadEstudiante = actividadEstudiante;
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
    [HttpPost("{postEstudianteId}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult CrearEstudiante([FromQuery] GradoEnum gradoId,  [FromBody] EstudianteDto estudianteCreate)
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
            if(!_estudiante.CreateEstudiante( gradoId, estudianteMap))
            {
                ModelState.AddModelError("", "Algo salio mal");
                return StatusCode(500,ModelState);
            }
            return Ok("gucci");
        }
        [HttpPut("{estudianteId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateEstudiante(int estudianteId, [FromQuery] GradoEnum gradoId,[FromBody] EstudianteDto estudianteUpdate)
        {
            if(estudianteUpdate ==null)
                return BadRequest(ModelState);
            if(estudianteId!= estudianteUpdate.Id)
                return BadRequest(ModelState);
            if (!_estudiante.EstudianteExiste(estudianteId))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest();
            var estudianteMap = _mapper.Map<Estudiante>(estudianteUpdate);
            if (!_estudiante.UpdateEstudiante(gradoId,estudianteMap))
            {
                ModelState.AddModelError("", "Algo salió mal");
                return StatusCode(500,ModelState);
            
            }
            return NoContent();
        }
        [HttpDelete("{deleteEstudianteId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteEstudiante (int estudianteId, [FromBody] EstudianteDto estudianteUpdate)
        {
            if (!_estudiante.EstudianteExiste(estudianteId))
            {
                return NotFound();
            }
            var estudianteDelete = _estudiante.GetEstudiante(estudianteId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!_estudiante.DeleteEstudiante(estudianteDelete))
            {
                ModelState.AddModelError("", "algo salio mal");
            }
            return NoContent();
        }
    }
    
}
