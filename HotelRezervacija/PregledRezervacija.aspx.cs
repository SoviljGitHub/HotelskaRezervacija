using PrezentacionaLogika;
using SlojPoslovneLogike;
using System;
using System.Data;
using System.Web.UI;

namespace HotelRezervacija
{
    public partial class PregledRezervacija : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UcitajRezervacije();
            }
        }

        private void UcitajRezervacije()
        {
            string jmbgGosta = Session["GostJMBG"] as string;
            if (string.IsNullOrEmpty(jmbgGosta))
            {
                Response.Redirect("GostPrijava.aspx");
                return;
            }

            var logika = new RezervacijaLogika();
            DataTable dt = logika.VratiRezervacijeZaGosta(jmbgGosta);
            if (dt == null)
            {
                lblPoruka.Text = "Nema podataka o rezervacijama.";
                return;
            }

            // Dodaj kolone ako nedostaju
            if (!dt.Columns.Contains("Popust"))
                dt.Columns.Add("Popust", typeof(decimal));
            if (!dt.Columns.Contains("Cena"))
                dt.Columns.Add("Cena", typeof(decimal));

            // Ako postoji kolona CenaPoNoci, izračunaj ukupnu cenu i popust
            bool imaCenuPoNoci = dt.Columns.Contains("CenaPoNoci");

            foreach (DataRow row in dt.Rows)
            {
                DateTime datumPrijave = Convert.ToDateTime(row["DatumPrijave"]);
                DateTime datumOdjave = Convert.ToDateTime(row["DatumOdjave"]);
                int brojDana = (datumOdjave - datumPrijave).Days;

                decimal ukupnaCena = 0m;
                if (imaCenuPoNoci)
                {
                    decimal cenaPoNoci = Convert.ToDecimal(row["CenaPoNoci"]);
                    ukupnaCena = PoslovnaLogika.IzracunajUkupnuCenu(cenaPoNoci, brojDana);
                    row["Cena"] = ukupnaCena;
                }

                decimal popust = PoslovnaLogika.IzracunajPopustProcenat(brojDana);
                row["Popust"] = popust;
            }

            gvRezervacije.DataSource = dt;
            gvRezervacije.DataBind();
        }

        protected void btnStampaj_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "print", "window.print();", true);
        }
    }
}
