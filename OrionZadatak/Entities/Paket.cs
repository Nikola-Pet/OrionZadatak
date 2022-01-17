using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

#nullable disable

namespace OrionZadatak.Entities
{
    public partial class Paket
    {
        [Required]
        public int PaketId { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        public string Opis { get; set; }
        [Required]
        public int Cena { get; set; }
        [Required]
        public string Kategorija { get; set; }


    }
}
