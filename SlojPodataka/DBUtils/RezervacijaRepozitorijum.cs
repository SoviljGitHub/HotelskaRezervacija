using SlojPodataka.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlojPodataka.DBUtils
{
    public class RezervacijaRepozitorijum : DBUtilsBaza
    {

        public bool SobaJeZauzeta(string brojSobe, DateTime datumOd, DateTime datumDo)
        {
            Parametri.Clear();
            Parametri["@BrojSobe"] = brojSobe;
            Parametri["@DatumOd"] = datumOd;
            Parametri["@DatumDo"] = datumDo;

            // Očekuje se da SP vrati 1 ako postoji bar jedna kolizija, inače 0
            object rez = IzvrsiSkalar("SobaJeZauzeta");
            int postoji = rez == null ? 0 : Convert.ToInt32(rez);
            return postoji > 0;
        }
        public bool DodajRezervaciju(Rezervacija rezervacija)
        {
            Parametri.Clear();
            Parametri["@JMBG_Gosta"] = rezervacija.JMBG_Gosta;
            Parametri["@BrojSobe"] = rezervacija.BrojSobe;
            Parametri["@DatumPrijave"] = rezervacija.DatumPrijave;
            Parametri["@DatumOdjave"] = rezervacija.DatumOdjave;
            Parametri["@Cena"] = rezervacija.Cena;

            int rezultat = IzvrsiBezRezultata("DodajRezervaciju");
            return rezultat > 0;
        }
    }
}
