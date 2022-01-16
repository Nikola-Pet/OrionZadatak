using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace OrionZadatak.Entities
{
    public partial class Ugovor
    {
        public int BrojUgovora { get; set; }
        public string KorisnickoIme { get; set; }
        public int TrajanjeUgovorneObaveze { get; set; }
        public int? Popust { get; set; }
        public int? GratisPeriod { get; set; }
        public int PaketId { get; set; }
        public bool Status { get; set; }
        public DateTime DatumKreiranja { get; set; }


        }
}
