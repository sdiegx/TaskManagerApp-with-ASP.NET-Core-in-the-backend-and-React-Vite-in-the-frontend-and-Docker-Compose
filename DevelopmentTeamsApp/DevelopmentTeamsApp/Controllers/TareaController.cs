using BusinessLayer.Interfaces;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevelopmentTeamsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        ITarea _tarea;
        public TareaController (ITarea tarea)
        {
            _tarea = tarea;
        }

        // GET: api/<TareaController>
        [HttpGet]
        public IEnumerable<Tarea> Get()
        {
            return _tarea.GetTareas();
        }

        // GET api/<TareaController>/5
        [HttpGet("{id}")]
        public ActionResult<Tarea> Get(int id)
        {
            if (_tarea.GetTarea(id) == null) return NotFound();
            return _tarea.GetTarea(id);
        }

        // POST api/<TareaController>
        [HttpPost]
        public ActionResult<Tarea> Post([FromBody] Tarea nuevaTarea)
        {
            if(nuevaTarea == null) return BadRequest("La tarea no puede ser nula");
            _tarea.AddTarea(nuevaTarea);
            return CreatedAtAction(nameof(Get), new { id = nuevaTarea.IdTarea }, nuevaTarea);
        }

        // PUT api/<TareaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Tarea nuevaTarea)
        {
            if (nuevaTarea == null || nuevaTarea.IdTarea != id)
                return BadRequest("Datos de la tarea no válidos.");
            _tarea.UpdateTarea(nuevaTarea);
            return NoContent();
        }

        // DELETE api/<TareaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _tarea.DeleteTarea(id);
            return NoContent();
        }
    }
}
