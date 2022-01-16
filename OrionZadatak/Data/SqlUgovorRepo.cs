using OrionZadatak.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrionZadatak.Data
{
    public class SqlUgovorRepo : IUgovorRepo
    {
        private readonly OrionZadatakContext _context;

        public SqlUgovorRepo (OrionZadatakContext context)
        {
            _context = context;
        }

        public int BrojUgovorabyAktivanStatus()
        {
            return _context.Ugovori.Where(x => x.Status == true).Count();
        }

        public int BrojUgovorabyNeaktivanStatus()
        {
            return _context.Ugovori.Where(x => x.Status == false).Count();
        }

        public int CenaPaketa(int id)
        {
            var ugovor = _context.Ugovori.FirstOrDefault(x => id == x.BrojUgovora);
            var cena = _context.Paketi.FirstOrDefault(x => ugovor.PaketId == x.PaketId).Cena;

            return cena;
        }

        public float Prihod(int trajanje, int? gratis, int? popust, int cena)
        {
            return (float)(trajanje - gratis) * cena*(1 - (float)popust / 100);
        }

    }
}
