using BusinessLayer.Interfaces;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevelopmentTeamsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasProyectoController : ControllerBase
    {
        ITareasProyecto _tareasProyecto;
        public TareasProyectoController(ITareasProyecto tareasProyecto)
        {
            _tareasProyecto = tareasProyecto;
        }

        // GET: api/<TareasProyectoController>
        [HttpGet]
        public IEnumerable<TareasProyecto> Get()
        {
            return _tareasProyecto.GetTareasProyectos();
        }

        // GET api/<TareasProyectoController>/5
        [HttpGet("{id}")]
        public ActionResult<TareasProyecto> Get(int id)
        {
            if (_tareasProyecto.GetTareasProyecto(id) == null) return NotFound();
            return _tareasProyecto.GetTareasProyecto(id);
        }

        // POST api/<TareasProyectoController>
        [HttpPost]
        public ActionResult<TareasProyecto> Post([FromBody] TareasProyecto nuevaTareasProyecto)
        {
            if (nuevaTareasProyecto == null) return BadRequest("La relacion entre proyecto y tarea no puede ser nula");
            _tareasProyecto.AddTareasProyecto(nuevaTareasProyecto);
            return CreatedAtAction(nameof(Get), new { id = nuevaTareasProyecto.IdTareaProyecto }, nuevaTareasProyecto);
        }

        // PUT api/<TareasProyectoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TareasProyecto nuevaTareasProyecto)
        {
            if (nuevaTareasProyecto == null || nuevaTareasProyecto.IdTareaProyecto != id)
                return BadRequest("Datos de la relacion entre tarea y proyecto no válidos.");
            _tareasProyecto.UpdateTareasProyecto(nuevaTareasProyecto);
            return NoContent();
        }

        // DELETE api/<TareasProyectoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _tareasProyecto.DeleteTareasProyecto(id);
            return NoContent();
        }
    }
}
