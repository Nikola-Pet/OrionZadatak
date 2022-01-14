using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrionZadatak.Entities;

namespace OrionZadatak.Controllers
{
    public class UgovoriController : Controller
    {
        private readonly OrionZadatakContext _context;

        public UgovoriController(OrionZadatakContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Ugovori.ToListAsync());
        }

       
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BrojUgovora,KorisnickoIme,TrajanjeUgovorneObaveze,Popust,GratisPeriod,Paket,Status")] Ugovor ugovor)
        {
            if (ModelState.IsValid)
            {
                ugovor.Status = true;
                _context.Add(ugovor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ugovor);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ugovor = await _context.Ugovori.FindAsync(id);
            if (ugovor == null)
            {
                return NotFound();
            }
            return View(ugovor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BrojUgovora,KorisnickoIme,TrajanjeUgovorneObaveze,Popust,GratisPeriod,Paket,Status")] Ugovor ugovor)
        {
            if (id != ugovor.BrojUgovora)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ugovor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UgovorExists(ugovor.BrojUgovora))
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
            return View(ugovor);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ugovor = await _context.Ugovori
                .FirstOrDefaultAsync(m => m.BrojUgovora == id);
            if (ugovor == null)
            {
                return NotFound();
            }

            return View(ugovor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ugovor = await _context.Ugovori.FindAsync(id);
            _context.Ugovori.Remove(ugovor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UgovorExists(int id)
        {
            return _context.Ugovori.Any(e => e.BrojUgovora == id);
        }
    }
}
