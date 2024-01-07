using BusinessLayer.Interfaces;
using DataLayer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevelopmentTeamsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoController : ControllerBase
    {
        IProyecto _proyecto;
        public ProyectoController (IProyecto proyecto)
        {
            _proyecto = proyecto;
        }
        // GET: api/<ProyectoController>
        [HttpGet]
        public IEnumerable<Proyecto> Get()
        {
            return _proyecto.GetProyectos();
        }

        // GET api/<ProyectoController>/5
        [HttpGet("{id}")]
        public ActionResult<Proyecto> Get(int id)
        {
            if(_proyecto.GetProyecto(id) == null) return NotFound();
            return _proyecto.GetProyecto(id);
        }

        // POST api/<ProyectoController>
        [HttpPost]
        public ActionResult<Proyecto> Post([FromBody] Proyecto nuevoProyecto)
        {
            if (nuevoProyecto == null) return BadRequest("El proyecto no puede ser nulo");
            _proyecto.AddProyecto(nuevoProyecto);
            return CreatedAtAction(nameof(Get), new { id = nuevoProyecto.IdProyecto }, nuevoProyecto);
        }

        // PUT api/<ProyectoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Proyecto nuevoProyecto)
        {
            if (nuevoProyecto == null || nuevoProyecto.IdProyecto != id)
                return BadRequest("Datos del Proyecto no válidos.");
            _proyecto.UpdateProyecto(nuevoProyecto);
            return NoContent();
        }

        // DELETE api/<ProyectoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _proyecto.DeleteProyecto(id);
            return NoContent();
        }
    }
}
