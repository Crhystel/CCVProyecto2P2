using ApiCCV2.Dto;
using ApiCCV2.Interfaces;
using ApiCCV2.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiCCV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadProfesoresController : Controller
    {
        private readonly IActividadProfesor _actividadProfesor;
        private readonly IMapper _mapper;
        public ActividadProfesoresController(IActividadProfesor actividadProfesor, IMapper mapper)
        {
            _actividadProfesor = actividadProfesor;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ActividadProfesor>))]
        public IActionResult GetActividadprofesores()
        {
            var actividadProfesor = _mapper.Map<List<ActividadProfesorDto>>(_actividadProfesor.GetActividadProfesores());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(actividadProfesor);

        }
        [HttpGet("{PorId}")]
        [ProducesResponseType(200, Type = typeof(ActividadProfesor))]
        [ProducesResponseType(400)]
        public IActionResult GetActividadProfesor(int apId)
        {
            if (!_actividadProfesor.ActividadProfesorExiste(apId))
                return NotFound();
            var actividadProfesor = _mapper.Map<ActividadProfesorDto>(_actividadProfesor.GetActividadProfesor(apId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(actividadProfesor);
        }
        [HttpGet("{PorPorfesor}")]
        [ProducesResponseType(200, Type = typeof(ActividadProfesor))]
        [ProducesResponseType(400)]
        public IActionResult GetActividadProfesorPorProfesor(int pId)
        {
            if (!_actividadProfesor.ActividadProfesorExiste(pId))
                return NotFound();
            var actividadProfesor = _mapper.Map<ActividadProfesorDto>(_actividadProfesor.GetActividadProfesorPorProfesor(pId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(actividadProfesor);
        }
        [HttpGet("{PorActividad}")]
        [ProducesResponseType(200, Type = typeof(ActividadProfesor))]
        [ProducesResponseType(400)]
        public IActionResult GetActividadProfesorPorActividad(int aId)
        {
            if (!_actividadProfesor.ActividadProfesorExiste(aId))
                return NotFound();
            var actividadProfesor = _mapper.Map<ActividadProfesorDto>(_actividadProfesor.GetActividadProfesorPorActividad(aId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(actividadProfesor);
        }

    }
}
