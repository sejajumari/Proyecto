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
    public class TipoMedicamentoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoMedicamentoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TipoMedicamento
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoMedicamento.ToListAsync());
        }

        // GET: TipoMedicamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMedicamento = await _context.TipoMedicamento
                .FirstOrDefaultAsync(m => m.TipoMedicamentoID == id);
            if (tipoMedicamento == null)
            {
                return NotFound();
            }

            return View(tipoMedicamento);
        }

        // GET: TipoMedicamento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoMedicamento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoMedicamentoID,Nombre")] TipoMedicamento tipoMedicamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoMedicamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoMedicamento);
        }

        // GET: TipoMedicamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMedicamento = await _context.TipoMedicamento.FindAsync(id);
            if (tipoMedicamento == null)
            {
                return NotFound();
            }
            return View(tipoMedicamento);
        }

        // POST: TipoMedicamento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoMedicamentoID,Nombre")] TipoMedicamento tipoMedicamento)
        {
            if (id != tipoMedicamento.TipoMedicamentoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoMedicamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoMedicamentoExists(tipoMedicamento.TipoMedicamentoID))
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
            return View(tipoMedicamento);
        }

        // GET: TipoMedicamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMedicamento = await _context.TipoMedicamento
                .FirstOrDefaultAsync(m => m.TipoMedicamentoID == id);
            if (tipoMedicamento == null)
            {
                return NotFound();
            }

            return View(tipoMedicamento);
        }

        // POST: TipoMedicamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoMedicamento = await _context.TipoMedicamento.FindAsync(id);
            _context.TipoMedicamento.Remove(tipoMedicamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoMedicamentoExists(int id)
        {
            return _context.TipoMedicamento.Any(e => e.TipoMedicamentoID == id);
        }
    }
}
