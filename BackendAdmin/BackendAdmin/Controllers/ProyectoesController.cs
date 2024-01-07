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
    public class ProyectoesController : Controller
    {
        private readonly DBDevelopmentAppContext _context;

        public ProyectoesController(DBDevelopmentAppContext context)
        {
            _context = context;
        }

        // GET: Proyectoes
        public async Task<IActionResult> Index()
        {
              return _context.Proyectos != null ? 
                          View(await _context.Proyectos.ToListAsync()) :
                          Problem("Entity set 'DBDevelopmentAppContext.Proyectos'  is null.");
        }

        // GET: Proyectoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Proyectos == null)
            {
                return NotFound();
            }

            var proyecto = await _context.Proyectos
                .FirstOrDefaultAsync(m => m.IdProyecto == id);
            if (proyecto == null)
            {
                return NotFound();
            }

            return View(proyecto);
        }

        // GET: Proyectoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proyectoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProyecto,NombreProyecto,FechaCreacion")] Proyecto proyecto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proyecto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proyecto);
        }

        // GET: Proyectoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Proyectos == null)
            {
                return NotFound();
            }

            var proyecto = await _context.Proyectos.FindAsync(id);
            if (proyecto == null)
            {
                return NotFound();
            }
            return View(proyecto);
        }

        // POST: Proyectoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProyecto,NombreProyecto,FechaCreacion")] Proyecto proyecto)
        {
            if (id != proyecto.IdProyecto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proyecto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProyectoExists(proyecto.IdProyecto))
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
            return View(proyecto);
        }

        // GET: Proyectoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Proyectos == null)
            {
                return NotFound();
            }

            var proyecto = await _context.Proyectos
                .FirstOrDefaultAsync(m => m.IdProyecto == id);
            if (proyecto == null)
            {
                return NotFound();
            }

            return View(proyecto);
        }

        // POST: Proyectoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Proyectos == null)
            {
                return Problem("Entity set 'DBDevelopmentAppContext.Proyectos'  is null.");
            }
            var proyecto = await _context.Proyectos.FindAsync(id);
            if (proyecto != null)
            {
                _context.Proyectos.Remove(proyecto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProyectoExists(int id)
        {
          return (_context.Proyectos?.Any(e => e.IdProyecto == id)).GetValueOrDefault();
        }
    }
}
