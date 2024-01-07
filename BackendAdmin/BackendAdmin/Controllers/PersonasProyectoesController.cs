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
    public class PersonasProyectoesController : Controller
    {
        private readonly DBDevelopmentAppContext _context;

        public PersonasProyectoesController(DBDevelopmentAppContext context)
        {
            _context = context;
        }

        // GET: PersonasProyectoes
        public async Task<IActionResult> Index()
        {
            var dBDevelopmentAppContext = _context.PersonasProyectos.Include(p => p.IdPersonaNavigation).Include(p => p.IdProyectoNavigation);
            return View(await dBDevelopmentAppContext.ToListAsync());
        }

        // GET: PersonasProyectoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PersonasProyectos == null)
            {
                return NotFound();
            }

            var personasProyecto = await _context.PersonasProyectos
                .Include(p => p.IdPersonaNavigation)
                .Include(p => p.IdProyectoNavigation)
                .FirstOrDefaultAsync(m => m.IdPersonaProyecto == id);
            if (personasProyecto == null)
            {
                return NotFound();
            }

            return View(personasProyecto);
        }

        // GET: PersonasProyectoes/Create
        public IActionResult Create()
        {
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona");
            ViewData["IdProyecto"] = new SelectList(_context.Proyectos, "IdProyecto", "IdProyecto");
            return View();
        }

        // POST: PersonasProyectoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPersonaProyecto,IdPersona,IdProyecto")] PersonasProyecto personasProyecto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personasProyecto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona", personasProyecto.IdPersona);
            ViewData["IdProyecto"] = new SelectList(_context.Proyectos, "IdProyecto", "IdProyecto", personasProyecto.IdProyecto);
            return View(personasProyecto);
        }

        // GET: PersonasProyectoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PersonasProyectos == null)
            {
                return NotFound();
            }

            var personasProyecto = await _context.PersonasProyectos.FindAsync(id);
            if (personasProyecto == null)
            {
                return NotFound();
            }
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona", personasProyecto.IdPersona);
            ViewData["IdProyecto"] = new SelectList(_context.Proyectos, "IdProyecto", "IdProyecto", personasProyecto.IdProyecto);
            return View(personasProyecto);
        }

        // POST: PersonasProyectoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPersonaProyecto,IdPersona,IdProyecto")] PersonasProyecto personasProyecto)
        {
            if (id != personasProyecto.IdPersonaProyecto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personasProyecto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonasProyectoExists(personasProyecto.IdPersonaProyecto))
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
            ViewData["IdPersona"] = new SelectList(_context.Personas, "IdPersona", "IdPersona", personasProyecto.IdPersona);
            ViewData["IdProyecto"] = new SelectList(_context.Proyectos, "IdProyecto", "IdProyecto", personasProyecto.IdProyecto);
            return View(personasProyecto);
        }

        // GET: PersonasProyectoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PersonasProyectos == null)
            {
                return NotFound();
            }

            var personasProyecto = await _context.PersonasProyectos
                .Include(p => p.IdPersonaNavigation)
                .Include(p => p.IdProyectoNavigation)
                .FirstOrDefaultAsync(m => m.IdPersonaProyecto == id);
            if (personasProyecto == null)
            {
                return NotFound();
            }

            return View(personasProyecto);
        }

        // POST: PersonasProyectoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PersonasProyectos == null)
            {
                return Problem("Entity set 'DBDevelopmentAppContext.PersonasProyectos'  is null.");
            }
            var personasProyecto = await _context.PersonasProyectos.FindAsync(id);
            if (personasProyecto != null)
            {
                _context.PersonasProyectos.Remove(personasProyecto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonasProyectoExists(int id)
        {
          return (_context.PersonasProyectos?.Any(e => e.IdPersonaProyecto == id)).GetValueOrDefault();
        }
    }
}
