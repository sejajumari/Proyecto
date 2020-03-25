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
    public class FacturaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FacturaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Factura
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Factura.Include(f => f.Cliente).Include(f => f.TipoPago).Include(f => f.Vendedor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Factura/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.Factura
                .Include(f => f.Cliente)
                .Include(f => f.TipoPago)
                .Include(f => f.Vendedor)
                .FirstOrDefaultAsync(m => m.FacturaID == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // GET: Factura/Create
        public IActionResult Create()
        {
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ClienteID", "ClienteID");
            ViewData["TipoPagoID"] = new SelectList(_context.TipoPago, "TipoPagoID", "TipoPagoID");
            ViewData["VendedorID"] = new SelectList(_context.Vendedor, "VendedorID", "VendedorID");
            return View();
        }

        // POST: Factura/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FacturaID,VendedorID,ClienteID,TipoPagoID,Fecha,Domicilio,Referencia,Direccion")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(factura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ClienteID", "ClienteID", factura.ClienteID);
            ViewData["TipoPagoID"] = new SelectList(_context.TipoPago, "TipoPagoID", "TipoPagoID", factura.TipoPagoID);
            ViewData["VendedorID"] = new SelectList(_context.Vendedor, "VendedorID", "VendedorID", factura.VendedorID);
            return View(factura);
        }

        // GET: Factura/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.Factura.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ClienteID", "ClienteID", factura.ClienteID);
            ViewData["TipoPagoID"] = new SelectList(_context.TipoPago, "TipoPagoID", "TipoPagoID", factura.TipoPagoID);
            ViewData["VendedorID"] = new SelectList(_context.Vendedor, "VendedorID", "VendedorID", factura.VendedorID);
            return View(factura);
        }

        // POST: Factura/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FacturaID,VendedorID,ClienteID,TipoPagoID,Fecha,Domicilio,Referencia,Direccion")] Factura factura)
        {
            if (id != factura.FacturaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturaExists(factura.FacturaID))
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
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ClienteID", "ClienteID", factura.ClienteID);
            ViewData["TipoPagoID"] = new SelectList(_context.TipoPago, "TipoPagoID", "TipoPagoID", factura.TipoPagoID);
            ViewData["VendedorID"] = new SelectList(_context.Vendedor, "VendedorID", "VendedorID", factura.VendedorID);
            return View(factura);
        }

        // GET: Factura/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.Factura
                .Include(f => f.Cliente)
                .Include(f => f.TipoPago)
                .Include(f => f.Vendedor)
                .FirstOrDefaultAsync(m => m.FacturaID == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // POST: Factura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var factura = await _context.Factura.FindAsync(id);
            _context.Factura.Remove(factura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaExists(int id)
        {
            return _context.Factura.Any(e => e.FacturaID == id);
        }
    }
}
