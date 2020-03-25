using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DrogNet.Data;
using DrogNet.Models;

namespace DrogNet.Controllers
{
    public class QuejaSugerenciaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuejaSugerenciaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QuejaSugerencia
        public async Task<IActionResult> Index()
        {
            return View(await _context.QuejaSugerencia.ToListAsync());
        }

        // GET: QuejaSugerencia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quejaSugerencia = await _context.QuejaSugerencia
                .FirstOrDefaultAsync(m => m.QuejaSugerenciaID == id);
            if (quejaSugerencia == null)
            {
                return NotFound();
            }

            return View(quejaSugerencia);
        }

        // GET: QuejaSugerencia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QuejaSugerencia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuejaSugerenciaID,Tema,Descripcion,Fecha")] QuejaSugerencia quejaSugerencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quejaSugerencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quejaSugerencia);
        }

        // GET: QuejaSugerencia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quejaSugerencia = await _context.QuejaSugerencia.FindAsync(id);
            if (quejaSugerencia == null)
            {
                return NotFound();
            }
            return View(quejaSugerencia);
        }

        // POST: QuejaSugerencia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuejaSugerenciaID,Tema,Descripcion,Fecha")] QuejaSugerencia quejaSugerencia)
        {
            if (id != quejaSugerencia.QuejaSugerenciaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quejaSugerencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuejaSugerenciaExists(quejaSugerencia.QuejaSugerenciaID))
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
            return View(quejaSugerencia);
        }

        // GET: QuejaSugerencia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quejaSugerencia = await _context.QuejaSugerencia
                .FirstOrDefaultAsync(m => m.QuejaSugerenciaID == id);
            if (quejaSugerencia == null)
            {
                return NotFound();
            }

            return View(quejaSugerencia);
        }

        // POST: QuejaSugerencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quejaSugerencia = await _context.QuejaSugerencia.FindAsync(id);
            _context.QuejaSugerencia.Remove(quejaSugerencia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuejaSugerenciaExists(int id)
        {
            return _context.QuejaSugerencia.Any(e => e.QuejaSugerenciaID == id);
        }
    }
}
