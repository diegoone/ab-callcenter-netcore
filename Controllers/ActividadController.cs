using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using supervisor_agente.Data;

namespace supervisor_agente.Controllers
{
    public class ActividadController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActividadController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Actividad
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Actividades.Include(a => a.asunto);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Actividad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actividad = await _context.Actividades
                .Include(a => a.asunto)
                .Include(a => a.usuarioApp)
                .FirstOrDefaultAsync(m => m.asuntoId == id);
            if (actividad == null)
            {
                return NotFound();
            }

            return View(actividad);
        }

        // GET: Actividad/Create
        public IActionResult Create()
        {
            ViewData["asuntoId"] = new SelectList(_context.Asuntos, "id", "id");
            ViewData["usuarioAppId"] = new SelectList(_context.UsuariosApp, "Id", "Id");
            return View();
        }

        // POST: Actividad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("fecha,correlativo,duracion,asuntoId,usuarioAppId")] Actividad actividad, 
        [Bind("motivo,tipo,estaResuelto")] Asunto Asunto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actividad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["asuntoId"] = new SelectList(_context.Asuntos, "id", "id", actividad.asuntoId);
            ViewData["usuarioAppId"] = new SelectList(_context.UsuariosApp, "Id", "Id", actividad.usuarioAppId);
            return View(actividad);
        }

        // GET: Actividad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actividad = await _context.Actividades.FindAsync(id);
            if (actividad == null)
            {
                return NotFound();
            }
            ViewData["asuntoId"] = new SelectList(_context.Asuntos, "id", "id", actividad.asuntoId);
            ViewData["usuarioAppId"] = new SelectList(_context.UsuariosApp, "Id", "Id", actividad.usuarioAppId);
            return View(actividad);
        }

        // POST: Actividad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("fecha,correlativo,duracion,asuntoId,usuarioAppId")] Actividad actividad)
        {
            if (id != actividad.asuntoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actividad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActividadExists(actividad.asuntoId))
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
            ViewData["asuntoId"] = new SelectList(_context.Asuntos, "id", "id", actividad.asuntoId);
            ViewData["usuarioAppId"] = new SelectList(_context.UsuariosApp, "Id", "Id", actividad.usuarioAppId);
            return View(actividad);
        }

        // GET: Actividad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actividad = await _context.Actividades
                .Include(a => a.asunto)
                .Include(a => a.usuarioApp)
                .FirstOrDefaultAsync(m => m.asuntoId == id);
            if (actividad == null)
            {
                return NotFound();
            }

            return View(actividad);
        }

        // POST: Actividad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actividad = await _context.Actividades.FindAsync(id);
            _context.Actividades.Remove(actividad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActividadExists(int id)
        {
            return _context.Actividades.Any(e => e.asuntoId == id);
        }
    }
}
