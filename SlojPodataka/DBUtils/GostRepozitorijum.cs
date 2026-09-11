using SlojPodataka.Modeli;
using System;
using System.Data;

namespace SlojPodataka.DBUtils
{
    public class GostRepozitorijum : DBUtilsBaza
    {
        public DataTable VratiSve()
        {
            Parametri.Clear();
            return IzvrsiCitanje(SaDboPrefiksom("VratiSveGoste"));
        }

        public bool Obrisi(string jmbg)
        {
            Parametri.Clear();
            Parametri["@JMBG"] = jmbg;
            int rez = IzvrsiBezRezultata(SaDboPrefiksom("ObrisiGosta"));
            return rez > 0;
        }
        public bool PostojiGost(string jmbg, string email = null)
        {
            Parametri.Clear();
            Parametri["@JMBG"] = jmbg;
            if (!string.IsNullOrWhiteSpace(email))
                Parametri["@Email"] = email;

            object val = IzvrsiSkalar(SaDboPrefiksom("PostojiGost"));
            int count = (val == null || val == DBNull.Value) ? 0 : Convert.ToInt32(val);
            return count > 0;
        }
        public bool DaLiPostojiGostSaJmbgIEmailom(string jmbg, string email) => PostojiGost(jmbg, email);

        public bool DodajGosta(Gost gost)
        {
            Parametri.Clear();
            Parametri["@Ime"] = gost.Ime;
            Parametri["@Prezime"] = gost.Prezime;
            Parametri["@JMBG"] = gost.JMBG;
            Parametri["@Pol"] = gost.Pol;
            Parametri["@DatumRodjenja"] = gost.DatumRodjenja;
            Parametri["@BrojTelefona"] = gost.BrojTelefona;
            Parametri["@Email"] = gost.Email;

            int rezultat = IzvrsiBezRezultata(SaDboPrefiksom("DodajGosta"));
            return rezultat > 0;
        }

       
    }
}
