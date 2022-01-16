using Microsoft.AspNetCore.Mvc.Rendering;
using OrionZadatak.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrionZadatak.Data
{
    public class SqlPaketRepo : IPaketRepo
    {
        private readonly OrionZadatakContext _context;

        public SqlPaketRepo(OrionZadatakContext context)
        {
            _context = context;
        }
        public SelectList NaziviPaketa ()
        {
           
            SelectList n = new SelectList(_context.Paketi.Select(p => p.Naziv).Distinct());

            return n;
        }

        public string NazivPaketa(int paketId)
        {
            return _context.Paketi.FirstOrDefault(x => x.PaketId == paketId).Naziv;

        }


    }
}
