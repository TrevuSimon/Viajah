using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Viajah.Models;
using Viajah.Services;

namespace Viajah.Controllers
{
    public class RegiaosController : Controller
    {
        private readonly ViajahContext _context;

        public RegiaosController(ViajahContext context)
        {
            _context = context;
        }

        // GET: Regiaos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Regiao.ToListAsync());
        }

        // GET: Regiaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regiao = await _context.Regiao
                .Include(a => a.RegiaoHistoria)
                    .ThenInclude(a => a.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regiao == null)
            {
                return NotFound();
            }

            return View(regiao);
        }

        // GET: Regiaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Regiaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,Cidade,Pais")] Regiao regiao)
        {
            if (ModelState.IsValid)
            {
                bool eModerador = Convert.ToBoolean(HttpContext.Session.GetString("Usuario.Moderador"));
                regiao.Aprovada = (eModerador)?true:false;
                _context.Add(regiao);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","Home");
            }
            return View(regiao);
        }

        // GET: Regiaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regiao = await _context.Regiao.FindAsync(id);
            if (regiao == null)
            {
                return NotFound();
            }
            return View(regiao);
        }

        // POST: Regiaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Regiao regiao)
        {
            if (id != regiao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regiao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegiaoExists(regiao.Id))
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
            return View(regiao);
        }

        // GET: Regiaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regiao = await _context.Regiao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regiao == null)
            {
                return NotFound();
            }

            return View(regiao);
        }

        // POST: Regiaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regiao = await _context.Regiao.FindAsync(id);
            _context.Regiao.Remove(regiao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegiaoExists(int id)
        {
            return _context.Regiao.Any(e => e.Id == id);
        }
    }
}
