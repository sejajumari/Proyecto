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
    public class VentaProductoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VentaProductoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VentaProducto
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.VentaProducto.Include(v => v.Factura).Include(v => v.Producto);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: VentaProducto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaProducto = await _context.VentaProducto
                .Include(v => v.Factura)
                .Include(v => v.Producto)
                .FirstOrDefaultAsync(m => m.VentaProductoID == id);
            if (ventaProducto == null)
            {
                return NotFound();
            }

            return View(ventaProducto);
        }

        // GET: VentaProducto/Create
        public IActionResult Create()
        {
            ViewData["FacturaID"] = new SelectList(_context.Factura, "FacturaID", "FacturaID");
            ViewData["ProductoID"] = new SelectList(_context.Producto, "ProductoID", "ProductoID");
            return View();
        }

        // POST: VentaProducto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VentaProductoID,FacturaID,ProductoID,Cantidad,Precio")] VentaProducto ventaProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventaProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FacturaID"] = new SelectList(_context.Factura, "FacturaID", "FacturaID", ventaProducto.FacturaID);
            ViewData["ProductoID"] = new SelectList(_context.Producto, "ProductoID", "ProductoID", ventaProducto.ProductoID);
            return View(ventaProducto);
        }

        // GET: VentaProducto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaProducto = await _context.VentaProducto.FindAsync(id);
            if (ventaProducto == null)
            {
                return NotFound();
            }
            ViewData["FacturaID"] = new SelectList(_context.Factura, "FacturaID", "FacturaID", ventaProducto.FacturaID);
            ViewData["ProductoID"] = new SelectList(_context.Producto, "ProductoID", "ProductoID", ventaProducto.ProductoID);
            return View(ventaProducto);
        }

        // POST: VentaProducto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VentaProductoID,FacturaID,ProductoID,Cantidad,Precio")] VentaProducto ventaProducto)
        {
            if (id != ventaProducto.VentaProductoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventaProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaProductoExists(ventaProducto.VentaProductoID))
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
            ViewData["FacturaID"] = new SelectList(_context.Factura, "FacturaID", "FacturaID", ventaProducto.FacturaID);
            ViewData["ProductoID"] = new SelectList(_context.Producto, "ProductoID", "ProductoID", ventaProducto.ProductoID);
            return View(ventaProducto);
        }

        // GET: VentaProducto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaProducto = await _context.VentaProducto
                .Include(v => v.Factura)
                .Include(v => v.Producto)
                .FirstOrDefaultAsync(m => m.VentaProductoID == id);
            if (ventaProducto == null)
            {
                return NotFound();
            }

            return View(ventaProducto);
        }

        // POST: VentaProducto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ventaProducto = await _context.VentaProducto.FindAsync(id);
            _context.VentaProducto.Remove(ventaProducto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentaProductoExists(int id)
        {
            return _context.VentaProducto.Any(e => e.VentaProductoID == id);
        }
    }
}
