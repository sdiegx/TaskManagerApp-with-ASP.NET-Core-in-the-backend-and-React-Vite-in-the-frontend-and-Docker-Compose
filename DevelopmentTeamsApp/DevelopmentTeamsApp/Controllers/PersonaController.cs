using BusinessLayer.Interfaces;
using DataLayer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevelopmentTeamsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        IPersona _persona;

        public PersonaController(IPersona persona)
        {
            _persona = persona;
        }

        // GET: api/<PersonaController>
        [HttpGet]
        public IEnumerable<Persona> Get()
        {
            return _persona.GetPersonas();
        }

        // GET api/<PersonaController>/5
        [HttpGet("{id}")]
        public ActionResult<Persona> Get(int id)
        {
            if (_persona.GetPersona(id) == null) return NotFound();
            return _persona.GetPersona(id);
        }

        // POST api/<PersonaController>
        [HttpPost]
        public ActionResult<Persona> Post([FromBody] Persona nuevaPersona)
        {
            if (nuevaPersona == null) return BadRequest("La persona no puede ser nula");
            _persona.AddPersona(nuevaPersona);
            return CreatedAtAction(nameof(Get), new { id = nuevaPersona.IdPersona }, nuevaPersona);
        }

        // PUT api/<PersonaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Persona nuevaPersona)
        {
            if (nuevaPersona == null || nuevaPersona.IdPersona != id)
                return BadRequest("Datos de la persona no válidos.");
            _persona.UpdatePersona(nuevaPersona);
            return NoContent();
        }

        // DELETE api/<PersonaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _persona.DeletePersona(id);
            return NoContent();
        }
    }
}
