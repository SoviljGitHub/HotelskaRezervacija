using PrezentacionaLogika;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelRezervacija
{
    public partial class GostPrijava : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPrijavi_Click(object sender, EventArgs e)
        {
            string jmbg = txtJMBG.Text.Trim();
            string email = txtEmail.Text.Trim();

            // Osnovna validacija
            if (jmbg.Length != 13 || !long.TryParse(jmbg, out _))
            {
                lblPoruka.Text = "JMBG mora imati tačno 13 cifara!";
                lblPoruka.ForeColor = System.Drawing.Color.Firebrick;
                return;
            }
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            {
                lblPoruka.Text = "Unesite ispravan email!";
                lblPoruka.ForeColor = System.Drawing.Color.Firebrick;
                return;
            }

            GostAutentifikacija logika = new GostAutentifikacija();
            bool postoji = logika.PrijaviGosta(jmbg, email);

            if (postoji)
            {
                // Čuvanje korisnika u sesiji (opciono)
                Session["GostJMBG"] = jmbg;
                Session["GostEmail"] = email;
                Response.Redirect("GostUspesnaPrijava.aspx");
            }
            else
            {
                lblPoruka.Text = "Prijava neuspešna! Proverite JMBG i Email.";
                lblPoruka.ForeColor = System.Drawing.Color.Firebrick;
            }
        }

    }
}