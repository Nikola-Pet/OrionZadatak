using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrionZadatak.Entities
{
    public class Istorija
    {
        public int Id { get; set; }
        public int BrojUgovora { get; set; }
        public DateTime Datum { get; set; }
        public bool Status { get; set; }
        public int Suma { get; set; }



    }
}
