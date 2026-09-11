using SlojPodataka.DBUtils;
using SlojPodataka.Modeli;
using SlojPoslovneLogike; // za poslovna pravila
using System;
using System.Data;
using System.Text.RegularExpressions;

namespace PrezentacionaLogika
{
    public class GostLogika
    {
        private readonly GostRepozitorijum repo = new GostRepozitorijum();

        public string Registruj(Gost g)
        {
            if (string.IsNullOrWhiteSpace(g.Ime) || string.IsNullOrWhiteSpace(g.Prezime) ||
                string.IsNullOrWhiteSpace(g.JMBG) || string.IsNullOrWhiteSpace(g.Email))
                return "Sva polja su obavezna.";

            if (!Regex.IsMatch(g.JMBG, @"^\d{13}$"))
                return "JMBG mora imati tačno 13 cifara.";

            if (!Regex.IsMatch(g.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return "Neispravna email adresa.";

            // Poslovno pravilo: zabrana registracije maloletnih (čita MinimalneGodine iz XML-a)
            try
            {
                PoslovnaLogika.ProveriStarost(g.DatumRodjenja);
            }
            catch (InvalidOperationException ex)
            {
                return ex.Message; // "Zabranjena registracija maloletne dece."
            }

            // ✔ jedinstvena provera postojanja
            if (repo.PostojiGost(g.JMBG))
                return "Gost sa tim JMBG već postoji.";

            bool uspesno = repo.DodajGosta(g);
            return uspesno ? "Uspešno ste se registrovali." : "Greška pri registraciji.";
        }

        // Vraća sve registrovane goste za grid/štampu
        public DataTable VratiSveGoste()
        {
            return repo.VratiSve();
        }

        // Brisanje gosta/registracije po JMBG
        public bool ObrisiGosta(string jmbg)
        {
            return repo.Obrisi(jmbg);
        }
    }
}
