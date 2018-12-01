using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Viajah.Models;
using Viajah.Services;

namespace Viajah.Controllers
{
    public class RegiaoHistoriasController : Controller
    {
        private readonly ViajahContext _context;

        public RegiaoHistoriasController(ViajahContext context)
        {
            _context = context;
        }

        // GET: RegiaoHistorias
        public async Task<IActionResult> Index()
        {
            var viajahContext = _context.RegiaoHistoria.Include(r => r.IdRegiaoNavigation);
            return View(await viajahContext.ToListAsync());
        }

        // GET: RegiaoHistorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regiaoHistoria = await _context.RegiaoHistoria
                .Include(r => r.IdRegiaoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regiaoHistoria == null)
            {
                return NotFound();
            }

            return View(regiaoHistoria);
        }

        // GET: RegiaoHistorias/Create
        public IActionResult Create(int? id)
        {
            ViewData["Id"] = new SelectList(_context.Regiao, "Id", "Cidade");

            RegiaoHistoria regiaoHistoria = new RegiaoHistoria();
            if (id.HasValue) regiaoHistoria.IdRegiao = id;

            return View(regiaoHistoria);
        }

        // POST: RegiaoHistorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Descricao,ExperienciasBoas,ExperienciasRuin,Conclusao,Indicacao,DataPostagem,IdRegiao")] RegiaoHistoria regiaoHistoria)
        {
            if (ModelState.IsValid)
            {
                regiaoHistoria.DataPostagem = DateTime.UtcNow;
                Usuario logged = HttpContext.Session.GetObject<Usuario>("Usuario");
                regiaoHistoria.IdUsuario = logged.Id;
                _context.Add(regiaoHistoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Regiao, "Id", "Cidade", regiaoHistoria.Id);
            return RedirectToAction("Details","Regiao",regiaoHistoria.IdRegiao);
        }

        // GET: RegiaoHistorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regiaoHistoria = await _context.RegiaoHistoria.FindAsync(id);
            if (regiaoHistoria == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Regiao, "Id", "Cidade", regiaoHistoria.Id);
            return View(regiaoHistoria);
        }

        // POST: RegiaoHistorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,ExperienciasBoas,ExperienciasRuin,Conclusao,Indicacao,DataPostagem,IdRegiao")] RegiaoHistoria regiaoHistoria)
        {
            if (id != regiaoHistoria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regiaoHistoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegiaoHistoriaExists(regiaoHistoria.Id))
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
            ViewData["Id"] = new SelectList(_context.Regiao, "Id", "Cidade", regiaoHistoria.Id);
            return View(regiaoHistoria);
        }

        // GET: RegiaoHistorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regiaoHistoria = await _context.RegiaoHistoria
                .Include(r => r.IdRegiaoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regiaoHistoria == null)
            {
                return NotFound();
            }

            return View(regiaoHistoria);
        }

        // POST: RegiaoHistorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regiaoHistoria = await _context.RegiaoHistoria.FindAsync(id);
            _context.RegiaoHistoria.Remove(regiaoHistoria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegiaoHistoriaExists(int id)
        {
            return _context.RegiaoHistoria.Any(e => e.Id == id);
        }
    }
}
