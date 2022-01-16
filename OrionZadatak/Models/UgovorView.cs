using OrionZadatak.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrionZadatak.Models
{
    public class UgovorView
    {
        public Ugovor Ugovor { get; set; }

        public IEnumerable<Ugovor> KolekcijaUgovora { get; set; }
        public IEnumerable<Ugovor> KolekcijaAktivnihUgovora { get; set; }

        public string NazivPaketa { get; set; }

        public IEnumerable<Istorija> Istorija { get; set; }

    }
}
