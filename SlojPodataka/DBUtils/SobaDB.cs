using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlojPodataka.DBUtils
{
    public class SobaDB : DBUtilsBaza
    {
        // Vraća sve sobe iz VIEW-a
        public DataTable VratiSveSobe()
        {
            Parametri.Clear();
            string upit = "SELECT * FROM Sobe_View";
            return IzvrsiCitanjeQuery(upit);
        }

        // Dodaje novu sobu
        public void DodajNovuSobu(string brojSobe, string tipSobe, int kapacitet, decimal cenaPoNoci)
        {
            Parametri.Clear();
            Parametri["@BrojSobe"] = brojSobe;
            Parametri["@TipSobe"] = tipSobe;
            Parametri["@Kapacitet"] = kapacitet;
            Parametri["@CenaPoNoci"] = cenaPoNoci;

            IzvrsiBezRezultata("DodajSobu");
        }

        // Izmena postojećih podataka sobe
        public void IzmeniSobu(int id, string brojSobe, string tipSobe, int kapacitet, decimal cenaPoNoci)
        {
            Parametri.Clear();
            Parametri["@Id"] = id;
            Parametri["@BrojSobe"] = brojSobe;
            Parametri["@TipSobe"] = tipSobe;
            Parametri["@Kapacitet"] = kapacitet;
            Parametri["@CenaPoNoci"] = cenaPoNoci;

            IzvrsiBezRezultata("IzmeniSobu");
        }

        // Brisanje sobe
        public void ObrisiSobu(int id)
        {
            Parametri.Clear();
            Parametri["@Id"] = id;

            IzvrsiBezRezultata("ObrisiSobu");
        }

        public bool DaLiBrojSobePostoji(string brojSobe)
        {
            using (var konekcija = new SqlConnection(putanjaKonekcije))
            using (var komanda = new SqlCommand("dbo.PostojiBrojSobe", konekcija))
            {
                komanda.CommandType = CommandType.StoredProcedure;

                // Uskladi dužinu sa SP parametrom/kolonom
                komanda.Parameters.Add("@BrojSobe", SqlDbType.NVarChar, 20).Value = brojSobe;

                konekcija.Open();
                object rez = komanda.ExecuteScalar();

                int postoji = (rez == null || rez == DBNull.Value) ? 0 : Convert.ToInt32(rez);
                return postoji > 0;
            }
        }


    }
}
