using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Angsoz.GerenciamentoAmigosAniversario.Web.Data;
using Angsoz.GerenciamentoAmigosAniversario.Web.Models;

namespace Angsoz.GerenciamentoAmigosAniversario.Web.Controllers
{
    public class PresentesController : Controller
    {
        private readonly Contexto _context;

        public PresentesController(Contexto context)
        {
            _context = context;
        }

        // GET: Presentes
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Presentes.Include(p => p.Pessoas);
            return View(await contexto.ToListAsync());
        }

        // GET: Presentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presente = await _context.Presentes
                .Include(p => p.Pessoas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (presente == null)
            {
                return NotFound();
            }

            return View(presente);
        }

        // GET: Presentes/Create
        public IActionResult Create()
        {
            ViewData["PessoaId"] = new SelectList(_context.Pessoas, "Id", "Nome");
            return View();
        }

        // POST: Presentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Presente presente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(presente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PessoaId"] = new SelectList(_context.Pessoas, "Id", "Nome", presente.PessoaId);
            return View(presente);
        }

        // GET: Presentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presente = await _context.Presentes.FindAsync(id);
            if (presente == null)
            {
                return NotFound();
            }
            ViewData["PessoaId"] = new SelectList(_context.Pessoas, "Id", "Nome", presente.PessoaId);
            return View(presente);
        }

        // POST: Presentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Presente presente)
        {
            if (id != presente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(presente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PresenteExists(presente.Id))
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
            ViewData["PessoaId"] = new SelectList(_context.Pessoas, "Id", "Nome", presente.PessoaId);
            return View(presente);
        }

        // GET: Presentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presente = await _context.Presentes
                .Include(p => p.Pessoas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (presente == null)
            {
                return NotFound();
            }

            return View(presente);
        }

        // POST: Presentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var presente = await _context.Presentes.FindAsync(id);
            _context.Presentes.Remove(presente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PresenteExists(int id)
        {
            return _context.Presentes.Any(e => e.Id == id);
        }
    }
}
