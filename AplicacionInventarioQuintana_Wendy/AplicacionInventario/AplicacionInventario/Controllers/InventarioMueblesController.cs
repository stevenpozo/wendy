using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AplicacionInventario.Models;

namespace AplicacionInventario.Controllers
{
    public class InventarioMueblesController : Controller
    {
        private readonly inventarioContext _context;

        public InventarioMueblesController(inventarioContext context)
        {
            _context = context;
        }

        // GET: InventarioMuebles
        public async Task<IActionResult> Index()
        {
              return _context.InventarioMuebles != null ? 
                          View(await _context.InventarioMuebles.ToListAsync()) :
                          Problem("Entity set 'inventarioContext.InventarioMuebles'  is null.");
        }

        // GET: InventarioMuebles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InventarioMuebles == null)
            {
                return NotFound();
            }

            var inventarioMueble = await _context.InventarioMuebles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventarioMueble == null)
            {
                return NotFound();
            }

            return View(inventarioMueble);
        }

        // GET: InventarioMuebles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InventarioMuebles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreMaterial,Descripcion,Categoria,Cantidad,Costo")] InventarioMueble inventarioMueble)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventarioMueble);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inventarioMueble);
        }

        // GET: InventarioMuebles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InventarioMuebles == null)
            {
                return NotFound();
            }

            var inventarioMueble = await _context.InventarioMuebles.FindAsync(id);
            if (inventarioMueble == null)
            {
                return NotFound();
            }
            return View(inventarioMueble);
        }

        // POST: InventarioMuebles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreMaterial,Descripcion,Categoria,Cantidad,Costo")] InventarioMueble inventarioMueble)
        {
            if (id != inventarioMueble.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventarioMueble);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventarioMuebleExists(inventarioMueble.Id))
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
            return View(inventarioMueble);
        }

        // GET: InventarioMuebles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InventarioMuebles == null)
            {
                return NotFound();
            }

            var inventarioMueble = await _context.InventarioMuebles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventarioMueble == null)
            {
                return NotFound();
            }

            return View(inventarioMueble);
        }

        // POST: InventarioMuebles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InventarioMuebles == null)
            {
                return Problem("Entity set 'inventarioContext.InventarioMuebles'  is null.");
            }
            var inventarioMueble = await _context.InventarioMuebles.FindAsync(id);
            if (inventarioMueble != null)
            {
                _context.InventarioMuebles.Remove(inventarioMueble);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventarioMuebleExists(int id)
        {
          return (_context.InventarioMuebles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
