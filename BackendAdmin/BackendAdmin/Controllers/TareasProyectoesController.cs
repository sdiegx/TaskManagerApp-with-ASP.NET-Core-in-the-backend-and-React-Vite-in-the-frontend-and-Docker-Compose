using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BackendAdmin.Models;

namespace BackendAdmin.Controllers
{
    public class TareasProyectoesController : Controller
    {
        private readonly DBDevelopmentAppContext _context;

        public TareasProyectoesController(DBDevelopmentAppContext context)
        {
            _context = context;
        }

        // GET: TareasProyectoes
        public async Task<IActionResult> Index()
        {
            var dBDevelopmentAppContext = _context.TareasProyectos.Include(t => t.IdProyectoNavigation).Include(t => t.IdTareaNavigation);
            return View(await dBDevelopmentAppContext.ToListAsync());
        }

        // GET: TareasProyectoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TareasProyectos == null)
            {
                return NotFound();
            }

            var tareasProyecto = await _context.TareasProyectos
                .Include(t => t.IdProyectoNavigation)
                .Include(t => t.IdTareaNavigation)
                .FirstOrDefaultAsync(m => m.IdTareaProyecto == id);
            if (tareasProyecto == null)
            {
                return NotFound();
            }

            return View(tareasProyecto);
        }

        // GET: TareasProyectoes/Create
        public IActionResult Create()
        {
            ViewData["IdProyecto"] = new SelectList(_context.Proyectos, "IdProyecto", "IdProyecto");
            ViewData["IdTarea"] = new SelectList(_context.Tareas, "IdTarea", "IdTarea");
            return View();
        }

        // POST: TareasProyectoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTareaProyecto,IdTarea,IdProyecto")] TareasProyecto tareasProyecto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tareasProyecto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProyecto"] = new SelectList(_context.Proyectos, "IdProyecto", "IdProyecto", tareasProyecto.IdProyecto);
            ViewData["IdTarea"] = new SelectList(_context.Tareas, "IdTarea", "IdTarea", tareasProyecto.IdTarea);
            return View(tareasProyecto);
        }

        // GET: TareasProyectoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TareasProyectos == null)
            {
                return NotFound();
            }

            var tareasProyecto = await _context.TareasProyectos.FindAsync(id);
            if (tareasProyecto == null)
            {
                return NotFound();
            }
            ViewData["IdProyecto"] = new SelectList(_context.Proyectos, "IdProyecto", "IdProyecto", tareasProyecto.IdProyecto);
            ViewData["IdTarea"] = new SelectList(_context.Tareas, "IdTarea", "IdTarea", tareasProyecto.IdTarea);
            return View(tareasProyecto);
        }

        // POST: TareasProyectoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTareaProyecto,IdTarea,IdProyecto")] TareasProyecto tareasProyecto)
        {
            if (id != tareasProyecto.IdTareaProyecto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tareasProyecto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TareasProyectoExists(tareasProyecto.IdTareaProyecto))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProyecto"] = new SelectList(_context.Proyectos, "IdProyecto", "IdProyecto", tareasProyecto.IdProyecto);
            ViewData["IdTarea"] = new SelectList(_context.Tareas, "IdTarea", "IdTarea", tareasProyecto.IdTarea);
            return View(tareasProyecto);
        }

        // GET: TareasProyectoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TareasProyectos == null)
            {
                return NotFound();
            }

            var tareasProyecto = await _context.TareasProyectos
                .Include(t => t.IdProyectoNavigation)
                .Include(t => t.IdTareaNavigation)
                .FirstOrDefaultAsync(m => m.IdTareaProyecto == id);
            if (tareasProyecto == null)
            {
                return NotFound();
            }

            return View(tareasProyecto);
        }

        // POST: TareasProyectoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TareasProyectos == null)
            {
                return Problem("Entity set 'DBDevelopmentAppContext.TareasProyectos'  is null.");
            }
            var tareasProyecto = await _context.TareasProyectos.FindAsync(id);
            if (tareasProyecto != null)
            {
                _context.TareasProyectos.Remove(tareasProyecto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TareasProyectoExists(int id)
        {
          return (_context.TareasProyectos?.Any(e => e.IdTareaProyecto == id)).GetValueOrDefault();
        }
    }
}
