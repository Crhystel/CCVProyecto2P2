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
        [HttpGet("{cId}")]
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
    }
}
