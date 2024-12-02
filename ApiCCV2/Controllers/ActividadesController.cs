using ApiCCV2.Dto;
using ApiCCV2.Interfaces;
using ApiCCV2.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiCCV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadesController : Controller
    {
        private readonly IActividad _actividad;
        private readonly IMapper _mapper;
        public ActividadesController(IActividad actividad, IMapper mapper)
        {
            _actividad = actividad;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Actividad>))]
        public IActionResult GetActividades()
        {
            var actividades = _mapper.Map<List<ActividadDto>>(_actividad.GetActividades());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(actividades);
        }
        [HttpGet("{PorId}")]
        [ProducesResponseType(200, Type = typeof(Actividad))]
        [ProducesResponseType(400)]
        public IActionResult GetActividad(int aId)
        {
            if (!_actividad.ActividadExiste(aId))
                return NotFound();
            var actividad = _mapper.Map<ActividadDto>(_actividad.GetActividad(aId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(actividad);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CrearActividad([FromQuery] int claseId, [FromQuery] int actividadId, [FromBody] Actividad actividadCreate)
        {
            if (actividadCreate == null)
                return BadRequest(ModelState);
            var actividades = _actividad.GetActividades()
                .Where(c => c.Id == claseId).FirstOrDefault();
            if (actividades != null)
            {
                ModelState.AddModelError("", "Actividad ya existe");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var actividadMap = _mapper.Map<Actividad>(actividadCreate);
            if (!_actividad.CreateActividad(claseId, actividadId, actividadMap)){
                ModelState.AddModelError("", "Algo malio sal");
                return StatusCode(500, ModelState);
            }
            return Ok("gucci");

        }
        [HttpPut("{actividadId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateActividad([FromQuery] int claseId, [FromQuery] int actividadId, [FromBody] ActividadDto actividadUpdate)
        {
            if(actividadUpdate==null)
                return BadRequest(ModelState);
            if(actividadId != actividadUpdate.Id)
                return BadRequest(ModelState);
            if(!_actividad.ActividadExiste(actividadId))
                return NotFound();
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var actividadesMap=_mapper.Map<Actividad>(actividadUpdate);
            if (!_actividad.UpdateActividad(claseId, actividadId, actividadesMap))
            {
                ModelState.AddModelError("", "Algo saliomal");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        [HttpDelete("{actividadId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteActividad(int actividadId,[FromBody]ActividadDto actividadUpdate)
        {
            if (!_actividad.ActividadExiste(actividadId))
            {
                return NotFound();
            }
            var actividadDelete = _actividad.GetActividad(actividadId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!_actividad.DeleteActividad(actividadDelete))
            {
                ModelState.AddModelError("", "algo salio mal");
            }
            return NoContent();
        }


    }

}
