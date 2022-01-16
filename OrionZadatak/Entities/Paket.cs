using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace OrionZadatak.Entities
{
    public partial class Paket
    {
        public int PaketId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public int Cena { get; set; }
        public string Kategorija { get; set; }


    }
}
