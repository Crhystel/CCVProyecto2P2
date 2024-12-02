using ApiCCV2.Dto;
using ApiCCV2.Interfaces;
using ApiCCV2.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiCCV2.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesoresController : Controller
    {
        private readonly IProfesor _profesor;
        private readonly IMapper _mapper;
        public ProfesoresController(IProfesor profesor, IMapper mapper)
        {
            _profesor = profesor;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Profesor>))]
        public IActionResult GetProfesores()
        {
            var profesores = _mapper.Map<List<ProfesorDto>>(_profesor.GetProfesores());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(profesores);

        }
        [HttpGet("{PorId}")]
        [ProducesResponseType(200, Type = typeof(Profesor))]
        [ProducesResponseType(400)]
        public IActionResult GetProfesor(int pId)
        {
            if (!_profesor.ProfesorExiste(pId))
                return NotFound();
            var profesor = _mapper.Map<ProfesorDto>(_profesor.GetProfesor(pId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(profesor);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CrearProfesor( [FromQuery] MateriaEnum materiaId,  [FromBody] ProfesorDto profesorCreate)
        {
            if (profesorCreate == null)
                return BadRequest(ModelState);
            var profesores = _profesor.GetProfesores()
                .Where(c => c.Nombre == profesorCreate.Nombre).FirstOrDefault();
            if (profesores != null)
            {
                ModelState.AddModelError("", "Profesor ya existe");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var profesorMap = _mapper.Map<Profesor>(profesorCreate);
            if (!_profesor.CreateProfesor(materiaId,  profesorMap))
            {
                ModelState.AddModelError("", "Algo salio mal");
                return StatusCode(500, ModelState);
            }
            return Ok("gucci");
        }
        [HttpPut("{profesorId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateProfesor(int profesorId, [FromQuery] MateriaEnum materiaId,  [FromBody] ProfesorDto profesorUpdate)
        {
            if (profesorUpdate == null)
                return BadRequest(ModelState);
            if (profesorId != profesorUpdate.Id)
                return BadRequest(ModelState);
            if (!_profesor.ProfesorExiste(profesorId))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest();
            var profesorMap = _mapper.Map<Profesor>(profesorUpdate);
            if (!_profesor.UpdateProfesor(materiaId, profesorMap))
            {
                ModelState.AddModelError("", "Algo salió mal");
                return StatusCode(500, ModelState);

            }
            return NoContent();
        }
        [HttpDelete("{profesorId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteProfesor(int profesorId, [FromBody] ProfesorDto profesorUpdate)
        {
            if (!_profesor.ProfesorExiste(profesorId))
            {
                return NotFound();
            }
            var profesorDelete = _profesor.GetProfesor(profesorId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!_profesor.DeleteProfesor(profesorDelete))
            {
                ModelState.AddModelError("", "algo salio mal");
            }
            return NoContent();
        }


    }
}


