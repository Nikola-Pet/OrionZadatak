﻿using OrionZadatak.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrionZadatak.Models
{
    public class PaketView
    {
        public IEnumerable<OrionZadatak.Entities.Paket> KolekcijaPaketa { get; set; }
        public Paket Paket { get; set; }

    }
}
