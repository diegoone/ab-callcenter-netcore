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
    public class AsuntoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AsuntoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Asunto
        public async Task<IActionResult> Index()
        {
            return View(await _context.Asuntos.ToListAsync());
        }

        // GET: Asunto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asunto = await _context.Asuntos
                .FirstOrDefaultAsync(m => m.id == id);
            if (asunto == null)
            {
                return NotFound();
            }

            return View(asunto);
        }

        // GET: Asunto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Asunto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,motivo,tipo,estaResuelto")] Asunto asunto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asunto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(asunto);
        }

        // GET: Asunto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asunto = await _context.Asuntos.FindAsync(id);
            if (asunto == null)
            {
                return View(new Asunto());
            }
            return View(asunto);
        }

        // POST: Asunto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,motivo,tipo,estaResuelto")] Asunto asunto)
        {
            if (id != asunto.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asunto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsuntoExists(asunto.id))
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
            return View(asunto);
        }

        // GET: Asunto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asunto = await _context.Asuntos
                .FirstOrDefaultAsync(m => m.id == id);
            if (asunto == null)
            {
                return NotFound();
            }

            return View(asunto);
        }

        // POST: Asunto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asunto = await _context.Asuntos.FindAsync(id);
            _context.Asuntos.Remove(asunto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsuntoExists(int id)
        {
            return _context.Asuntos.Any(e => e.id == id);
        }
    }
}
