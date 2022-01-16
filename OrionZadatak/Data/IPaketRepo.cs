using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrionZadatak.Data
{
    public interface IPaketRepo
    {
        SelectList NaziviPaketa();
        string NazivPaketa(int paketId);
    }
}
