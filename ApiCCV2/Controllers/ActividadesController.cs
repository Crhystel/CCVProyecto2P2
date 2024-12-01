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
            var actividades= _mapper.Map<List<ActividadDto>>(_actividad.GetActividades());
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
    }

}
