using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrionZadatak.Data;
using OrionZadatak.Entities;
using OrionZadatak.Models;

namespace OrionZadatak.Controllers
{
    public class UgovoriController : Controller
    {
        private readonly OrionZadatakContext _context;
        private readonly IPaketRepo _paketRepo;
        private readonly IUgovorRepo _ugovorRepo;

        


        public UgovoriController(OrionZadatakContext context, IPaketRepo paketRepo, IUgovorRepo ugovorRepo)
        {
            _context = context;
            _paketRepo = paketRepo;
            _ugovorRepo = ugovorRepo;
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
        public async Task<IActionResult> Create([Bind("BrojUgovora,KorisnickoIme,TrajanjeUgovorneObaveze,Popust,GratisPeriod,NazivPaketa,Status")] Ugovor ugovor, UgovorView ugovorView)
        {
            if (ModelState.IsValid)
            {
                ugovor.Status = true;
                ugovor.DatumKreiranja = DateTime.Now;

                var a = _context.Paketi.Where(x => x.Naziv == ugovorView.NazivPaketa);
                var b = a.Select(x => x.PaketId);
                ugovor.PaketId = b.FirstOrDefault();
                
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

            var istorija = _context.Istorije.Where(x => x.BrojUgovora == id);

            var ugovor  = await _context.Ugovori.FindAsync(id);

            if (ugovor == null)
            {
                return NotFound();
            }
            UgovorView ugovorView = new UgovorView()
            {
                Ugovor = ugovor,
                Istorija = istorija
            };
            return View(ugovorView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BrojUgovora,KorisnickoIme,TrajanjeUgovorneObaveze,Popust,GratisPeriod,NazivPaketa,Status")] Ugovor ugovor, UgovorView ugovorView)
        {
          
            if (id != ugovor.BrojUgovora)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ugovor.DatumKreiranja = DateTime.Now;

                    var a = _context.Paketi.Where(x => x.Naziv == ugovorView.NazivPaketa);
                    var b = a.Select(x => x.PaketId);
                    ugovor.PaketId = b.FirstOrDefault();

                    _context.Update(ugovor);

                    Istorija istorija = new Istorija()
                    {
                        BrojUgovora = ugovor.BrojUgovora,
                        Datum = ugovor.DatumKreiranja,
                        Status = ugovor.Status,
                        Suma = _ugovorRepo.CenaPaketa(ugovor.BrojUgovora)
                    };
                    _context.Add(istorija);

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
            var istorija = _context.Istorije.Where(x => x.BrojUgovora == id).ToArray();
            _context.Istorije.RemoveRange(istorija);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UgovorExists(int id)
        {
            return _context.Ugovori.Any(e => e.BrojUgovora == id);
        }
    }
}
