using SlojPodataka.DBUtils;
using SlojPodataka.Modeli;
using System;
using System.Data;
using SlojPoslovneLogike;

namespace PrezentacionaLogika
{
    public class RezervacijaLogika
    {
        private readonly RezervacijaRepozitorijum repo = new RezervacijaRepozitorijum();

        public string PosaljiRezervaciju(Rezervacija r)
        {
            // (postojeci uslovi)
            if (string.IsNullOrWhiteSpace(r.JMBG_Gosta) || string.IsNullOrWhiteSpace(r.BrojSobe))
                return "Morate uneti JMBG gosta i izabrati sobu.";

            if (!long.TryParse(r.JMBG_Gosta, out _) || r.JMBG_Gosta.Length != 13)
                return "JMBG gosta mora imati tačno 13 cifara.";

            if (r.DatumPrijave >= r.DatumOdjave)
                return "Datum odjave mora biti posle datuma prijave.";

            int brojDana = (r.DatumOdjave - r.DatumPrijave).Days;

            if (!PoslovnaLogika.DaLiJeBoravakValidan(brojDana))
                return "Boravak mora biti između 1 i 30 dana.";

            bool zauzeta = repo.SobaJeZauzeta(r.BrojSobe, r.DatumPrijave, r.DatumOdjave);  
            if (zauzeta)                                                                     
                return $"Soba {r.BrojSobe} je zauzeta u traženom terminu.";                

            // Ako je sve ok – upiši
            bool uspesno = repo.DodajRezervaciju(r);
            return uspesno ? "Uspešno ste rezervisali boravak." : "Greška pri unosu rezervacije.";
        }

        public DataTable VratiRezervacijeZaGosta(string jmbgGosta)
        {
            RezervacijaPregledDB db = new RezervacijaPregledDB();
            return db.VratiRezervacijeZaGosta(jmbgGosta);
        }
    }
}
