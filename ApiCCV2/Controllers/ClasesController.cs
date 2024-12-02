using ApiCCV2.Dto;
using ApiCCV2.Interfaces;
using ApiCCV2.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiCCV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClasesController : Controller
    {
        private readonly IClase _clase;
        private readonly IMapper _mapper;
        public ClasesController(IClase clase, IMapper mapper)
        {
            _clase = clase;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Clase>))]
        public IActionResult GetClases()
        {
            var clases = _mapper.Map<List<Clase>>(_clase.GetClases());
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(clases);
        }
        [HttpGet("{PorId}")]
        [ProducesResponseType(200, Type = typeof(Clase))]
        [ProducesResponseType(400)]
        public IActionResult GetClase(int cId)
        {
            if(!_clase.ClaseExiste(cId))
                return NotFound();
            var clase = _mapper.Map<Clase>(_clase.GetClase(cId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(clase);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CrearClase([FromQuery] int claseId,[FromQuery] int estudiantesId,[FromQuery] int profesoresId, [FromBody] ClaseDto claseCreate)
        {
            if (claseCreate == null)
                return BadRequest(ModelState);
            var clases = _clase.GetClases()
                .Where(c => c.Id == claseCreate.Id).FirstOrDefault();
            if (clases != null)
            {
                ModelState.AddModelError("", "Clase ya existe");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var claseMap = _mapper.Map<Clase>(claseCreate);
            if (!_clase.CreateClase(claseId, estudiantesId, profesoresId ,claseMap))
            {
                ModelState.AddModelError("", "Algo salio mal");
                return StatusCode(500, ModelState);
            }
            return Ok("gucci");
        }
        [HttpPut("{claseId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateClase(int claseId, [FromQuery] int estudianteId, [FromQuery] int profesorId, [FromBody] ClaseDto claseUpdate)
        {
            if(claseUpdate == null)
                return BadRequest(ModelState);
            if(claseId!= claseUpdate.Id)
                return BadRequest(ModelState);
            if(!_clase.ClaseExiste(claseId))
                return NotFound();
            if(!ModelState.IsValid) 
                return BadRequest();
            var claseMap = _mapper.Map<Clase>(claseUpdate);
            if(!_clase.UpdateClase(claseId, estudianteId,profesorId, claseMap))
            {
                ModelState.AddModelError("", "Algo salion mal");
                return StatusCode(500, ModelState);
            }
            return NoContent();

        }
        [HttpDelete("{claseId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteProfesor(int claseId,[FromBody] ClaseDto claseUpdate)
        {
            if (!_clase.ClaseExiste(claseId))
            {
                return NotFound();
            }
            var clasedelete = _clase.GetClase(claseId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!_clase.DeleteClase(clasedelete))
            {
                ModelState.AddModelError("", "algo salio mal");
            }
            return NoContent();
        }
    }
}
