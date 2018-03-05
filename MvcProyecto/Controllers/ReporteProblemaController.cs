using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcProyecto.Models;

namespace MvcProyecto.Controllers
{
    public class ReporteProblemaController : Controller
    {
        private readonly MvcProyectoContext _context;

        public ReporteProblemaController(MvcProyectoContext context)
        {
            _context = context;
        }

        // GET: ReporteProblema
        public async Task<IActionResult> Index()
        {
            var mvcProyectoContext = _context.ReporteProblema.Include(r => r.Cliente);
            return View(await mvcProyectoContext.ToListAsync());
        }

        // GET: ReporteProblema/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reporteProblema = await _context.ReporteProblema
                .Include(r => r.Cliente)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (reporteProblema == null)
            {
                return NotFound();
            }

            return View(reporteProblema);
        }

        // GET: ReporteProblema/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ID", "Nombre");
            return View();
        }

        // POST: ReporteProblema/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TituloProblema,DetalleProblema,QuienReporto,ClienteId,Estado")] ReporteProblema reporteProblema)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reporteProblema);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ID", "ID", reporteProblema.ClienteId);
            return View(reporteProblema);
        }

        // GET: ReporteProblema/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reporteProblema = await _context.ReporteProblema.SingleOrDefaultAsync(m => m.ID == id);
            if (reporteProblema == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ID", "Nombre", reporteProblema.ClienteId);
            return View(reporteProblema);
        }

        // POST: ReporteProblema/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TituloProblema,DetalleProblema,QuienReporto,ClienteId,Estado")] ReporteProblema reporteProblema)
        {
            if (id != reporteProblema.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reporteProblema);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReporteProblemaExists(reporteProblema.ID))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "ID", "ID", reporteProblema.ClienteId);
            return View(reporteProblema);
        }

        // GET: ReporteProblema/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reporteProblema = await _context.ReporteProblema
                .Include(r => r.Cliente)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (reporteProblema == null)
            {
                return NotFound();
            }

            return View(reporteProblema);
        }

        // POST: ReporteProblema/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reporteProblema = await _context.ReporteProblema.SingleOrDefaultAsync(m => m.ID == id);
            _context.ReporteProblema.Remove(reporteProblema);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReporteProblemaExists(int id)
        {
            return _context.ReporteProblema.Any(e => e.ID == id);
        }
    }
}
