using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlojPodataka.Modeli
{
    public class Rezervacija
    {
        public int IdRezervacije { get; set; }
        public string JMBG_Gosta { get; set; }
        public string BrojSobe { get; set; }
        public DateTime DatumPrijave { get; set; }
        public DateTime DatumOdjave { get; set; }
        public decimal Cena { get; set; }
    }
}
