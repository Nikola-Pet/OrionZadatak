using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrionZadatak.Data
{
    public interface IUgovorRepo
    {
         int BrojUgovorabyAktivanStatus();
         int BrojUgovorabyNeaktivanStatus();

        float Prihod(int trajanje, int? gratis, int? popust, int cena);

        int CenaPaketa(int id);
    }
}
