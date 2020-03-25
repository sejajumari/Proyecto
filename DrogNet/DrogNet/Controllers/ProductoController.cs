using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DrogNet.Data;
using DrogNet.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using DrogNet.ViewModels;

namespace DrogNet.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment Hosting;
        public ProductoController(ApplicationDbContext context, IHostingEnvironment hosting)
        {
            _context = context;
            Hosting = hosting;
        }

        // GET: Producto
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Producto.Include(p => p.TipoMedicamento);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Producto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto
                .Include(p => p.TipoMedicamento)
                .FirstOrDefaultAsync(m => m.ProductoID == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Producto/Create
        public IActionResult Create()
        {
            ViewData["TipoMedicamentoID"] = new SelectList(_context.TipoMedicamento, "TipoMedicamentoID", "TipoMedicamentoID");
            return View("ProductoViewModel");
        }

        // POST: Producto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductoViewModel producto)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (producto.Photo != null)
                {
                    string uploadsFolder = Path.Combine(Hosting.WebRootPath, "images");
                    uniqueFileName = $"{DateTime.Now.ToString("yyyyMMddHHmmss")}{producto.Photo.FileName}"; string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    producto.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                    Producto newDetalle = new Producto
                    {
                        TipoMedicamentoID = producto.TipoMedicamentoID,
                        Nombre = producto.Nombre,
                        Laboratorio = producto.Laboratorio,
                        Precio = producto.Precio,
                        Lote = producto.Lote,
                        FechaVencimiento = producto.FechaVencimiento,
                        PathFile = uniqueFileName
                    };
                    _context.Producto.Add(newDetalle); 
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index),new{ id = newDetalle.ProductoID });
                }
          
            }

            ViewData["TipoMedicamentoID"] = new SelectList(_context.TipoMedicamento, "TipoMedicamentoID", "Nombre", producto.TipoMedicamentoID);
            ViewData["ProductoID"] = new SelectList(_context.Set<Producto>(), "ProductoID", "Nombre", producto.ProductoID);
            return View(producto);
        }
        // GET: Producto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewData["TipoMedicamentoID"] = new SelectList(_context.TipoMedicamento, "TipoMedicamentoID", "TipoMedicamentoID", producto.TipoMedicamentoID);
            return View(producto);
        }

        // POST: Producto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductoID,Nombre,TipoMedicamentoID,Laboratorio,Precio,Lote,PathFile,FechaVencimiento")] Producto producto)
        {
            if (id != producto.ProductoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.ProductoID))
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
            ViewData["TipoMedicamentoID"] = new SelectList(_context.TipoMedicamento, "TipoMedicamentoID", "TipoMedicamentoID", producto.TipoMedicamentoID);
            return View(producto);
        }

        // GET: Producto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Producto
                .Include(p => p.TipoMedicamento)
                .FirstOrDefaultAsync(m => m.ProductoID == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producto = await _context.Producto.FindAsync(id);
            _context.Producto.Remove(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return _context.Producto.Any(e => e.ProductoID == id);
        }
    }
}
