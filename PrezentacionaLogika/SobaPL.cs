using SlojPodataka.DBUtils;
using System;
using System.Collections.Generic;
using System.Data;

namespace PrezentacionaLogika
{
    public class SobaPL
    {
        private readonly SobaDB db = new SobaDB();

        public DataTable UcitajSobe()
        {
            return db.VratiSveSobe();
        }

        public void DodajSobu(string brojSobe, string tipSobe, int kapacitet, decimal cenaPoNoci)
        {
            db.DodajNovuSobu(brojSobe, tipSobe, kapacitet, cenaPoNoci);
        }

        public void IzmeniSobu(int id, string brojSobe, string tipSobe, int kapacitet, decimal cenaPoNoci)
        {
            db.IzmeniSobu(id, brojSobe, tipSobe, kapacitet, cenaPoNoci);
        }

        public void ObrisiSobu(int id)
        {
            db.ObrisiSobu(id);
        }

        public bool DaLiBrojSobePostoji(string brojSobe)
        {
            return db.DaLiBrojSobePostoji(brojSobe);
        }


        public List<KeyValuePair<string, string>> VratiSobeZaDropdown()
        {
            DataTable dt = db.VratiSveSobe();
            List<KeyValuePair<string, string>> lista = new List<KeyValuePair<string, string>>();
            lista.Add(new KeyValuePair<string, string>("-- Izaberite sobu --", ""));

            foreach (DataRow red in dt.Rows)
            {
                string tekst = $"Soba {red["BrojSobe"]} ({red["TipSobe"]})";
                string vrednost = red["Id"].ToString();
                lista.Add(new KeyValuePair<string, string>(tekst, vrednost));
            }

            return lista;
        }
    }
}
