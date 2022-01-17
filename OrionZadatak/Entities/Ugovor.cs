using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace OrionZadatak.Entities
{
    public partial class Ugovor
    {
        [Required]
        public int BrojUgovora { get; set; }
        [Required]
        public string KorisnickoIme { get; set; }
        [Required]
        public int TrajanjeUgovorneObaveze { get; set; }
        public int? Popust { get; set; }
        public int? GratisPeriod { get; set; }
        [Required]
        public int PaketId { get; set; }
        public bool Status { get; set; }
        public DateTime DatumKreiranja { get; set; }


        }
}
