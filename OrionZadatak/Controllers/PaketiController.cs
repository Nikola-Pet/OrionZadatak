using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrionZadatak.Entities;
using OrionZadatak.Models;

namespace OrionZadatak.Controllers
{
    public class PaketiController : Controller
    {
        private readonly OrionZadatakContext _context;


        public PaketiController(OrionZadatakContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new PaketView();
            model.KolekcijaPaketa = _context.Paketi.ToList();

          
            return View(model);
        }


        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaketId,Naziv,Opis,Cena,Kategorija")] Paket paket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paket);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paket = await _context.Paketi.FindAsync(id);
            if (paket == null)
            {
                return NotFound();
            }
            return View(paket);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaketId,Naziv,Opis,Cena,Kategorija")] Paket paket)
        {
            if (id != paket.PaketId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaketExists(paket.PaketId))
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
            return View(paket);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paket = await _context.Paketi
                .FirstOrDefaultAsync(m => m.PaketId == id);
            if (paket == null)
            {
                return NotFound();
            }

            return View(paket);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var paket = await _context.Paketi.FindAsync(id);
            _context.Paketi.Remove(paket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaketExists(int id)
        {
            return _context.Paketi.Any(e => e.PaketId == id);
        }
    }
}
