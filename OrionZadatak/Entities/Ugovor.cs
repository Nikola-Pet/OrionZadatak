using System;
using System.Collections.Generic;

#nullable disable

namespace OrionZadatak.Entities
{
    public partial class Ugovor
    {
        public int BrojUgovora { get; set; }
        public string KorisnickoIme { get; set; }
        public string TrajanjeUgovorneObaveze { get; set; }
        public int? Popust { get; set; }
        public int? GratisPeriod { get; set; }
        public string Paket { get; set; }
        public bool Status { get; set; }
    }
}
