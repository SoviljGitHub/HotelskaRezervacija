using PrezentacionaLogika;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace HotelRezervacija
{
    public partial class Soba : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UcitajSobe();
                btnIzmeni.Visible = false;
            }
        }

        private void UcitajSobe()
        {
            SobaPL pl = new SobaPL();
            gvSobe.DataSource = pl.UcitajSobe();
            gvSobe.DataBind();
        }

        protected void btnDodaj_Click(object sender, EventArgs e)
        {
            int kapacitet;
            decimal cena;
            if (string.IsNullOrWhiteSpace(txtBrojSobe.Text) || string.IsNullOrWhiteSpace(txtTipSobe.Text)
                || !int.TryParse(txtKapacitet.Text.Trim(), out kapacitet)
                || !decimal.TryParse(txtCenaPoNoci.Text.Trim(), out cena))
            {
                lblPoruka.Text = "Sva polja su obavezna i moraju biti validna!";
                return;
            }

            SobaPL pl = new SobaPL();

            // *** PROVERA: Da li broj sobe već postoji ***
            if (pl.DaLiBrojSobePostoji(txtBrojSobe.Text.Trim()))
            {
                lblPoruka.Text = "Broj sobe već postoji! Unesite drugi broj.";
                return;
            }
            // *** Kraj provere ***

            pl.DodajSobu(txtBrojSobe.Text.Trim(), txtTipSobe.Text.Trim(), kapacitet, cena);

            lblPoruka.Text = "Soba uspešno dodata.";
            ResetujFormu();
            UcitajSobe();
        }

        protected void btnIzmeni_Click(object sender, EventArgs e)
        {
            int id, kapacitet;
            decimal cena;
            if (!int.TryParse(hfIdSobe.Value, out id) ||
                string.IsNullOrWhiteSpace(txtBrojSobe.Text) ||
                string.IsNullOrWhiteSpace(txtTipSobe.Text) ||
                !int.TryParse(txtKapacitet.Text.Trim(), out kapacitet) ||
                !decimal.TryParse(txtCenaPoNoci.Text.Trim(), out cena))
            {
                lblPoruka.Text = "Greška u izmeni.";
                return;
            }

            SobaPL pl = new SobaPL();
            pl.IzmeniSobu(id, txtBrojSobe.Text.Trim(), txtTipSobe.Text.Trim(), kapacitet, cena);

            lblPoruka.Text = "Izmene sačuvane.";
            ResetujFormu();
            btnDodaj.Visible = true;
            btnIzmeni.Visible = false;
            UcitajSobe();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ResetujFormu();
        }

        private void ResetujFormu()
        {
            hfIdSobe.Value = "";
            txtBrojSobe.Text = "";
            txtTipSobe.Text = "";
            txtKapacitet.Text = "";
            txtCenaPoNoci.Text = "";
            btnDodaj.Visible = true;
            btnIzmeni.Visible = false;
            lblPoruka.Text = "";
        }

        protected void gvSobe_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "IzmeniRed")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvSobe.Rows[index];

                hfIdSobe.Value = gvSobe.DataKeys[index].Value.ToString();
                txtBrojSobe.Text = row.Cells[0].Text;
                txtTipSobe.Text = row.Cells[1].Text;
                txtKapacitet.Text = row.Cells[2].Text;
                txtCenaPoNoci.Text = row.Cells[3].Text;

                btnDodaj.Visible = false;
                btnIzmeni.Visible = true;
            }
            else if (e.CommandName == "Delete")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int id = Convert.ToInt32(gvSobe.DataKeys[index].Value);
                SobaPL pl = new SobaPL();
                pl.ObrisiSobu(id);
                lblPoruka.Text = "Soba obrisana.";
                UcitajSobe();
            }
        }

        protected void gvSobe_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Potrebno zbog GridViewa, logika brisanja je u RowCommand
        }

        protected void gvSobe_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSobe.PageIndex = e.NewPageIndex;
            UcitajSobe();
        }
    }
}
