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
        

    }
}


