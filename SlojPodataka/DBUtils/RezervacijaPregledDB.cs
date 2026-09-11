using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SlojPodataka.DBUtils
{
    public class RezervacijaPregledDB : DBUtilsBaza
    {
        public DataTable VratiRezervacijeZaGosta(string jmbg)
        {
            Parametri.Clear();
            Parametri["@JMBG"] = jmbg;

            string upit = "SELECT * FROM vw_RezervacijeGostiju WHERE JMBG = @JMBG";
            return IzvrsiCitanjeQuery(upit);
        }
    }

}
