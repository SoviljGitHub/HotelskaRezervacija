using PrezentacionaLogika;
using System;
using System.Web.UI;
using SlojPodataka.Modeli;

namespace HotelRezervacija
{
    public partial class PrijavaRezervacije : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Napuni dropdown sa brojevima soba
                var sobe = new SobaPL().UcitajSobe(); 
                ddlBrojSobe.DataSource = sobe;
                ddlBrojSobe.DataTextField = "BrojSobe";
                ddlBrojSobe.DataValueField = "BrojSobe";
                ddlBrojSobe.DataBind();
            }
        }

        protected void btnRezervisi_Click(object sender, EventArgs e)
        {
            string jmbg = txtJMBG.Text.Trim();
            string brojSobe = ddlBrojSobe.SelectedValue; 
            DateTime datumPrijave, datumOdjave;
            if (!DateTime.TryParse(txtDatumPrijave.Text, out datumPrijave) ||
                !DateTime.TryParse(txtDatumOdjave.Text, out datumOdjave))
            {
                lblPoruka.Text = "Unesite validne datume.";
                return;
            }

            // Ostatak logike: cena možeš da računaš kasnije u pregledu
            Rezervacija rezervacija = new Rezervacija
            {
                JMBG_Gosta = jmbg,
                BrojSobe = brojSobe, 
                DatumPrijave = datumPrijave,
                DatumOdjave = datumOdjave,
                // Cena će biti izračunata kasnije
            };

            RezervacijaLogika logika = new RezervacijaLogika();
            string rezultat = logika.PosaljiRezervaciju(rezervacija);
            lblPoruka.Text = rezultat;
        }
    }
}
