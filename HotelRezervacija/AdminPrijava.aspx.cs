using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PrezentacionaLogika;

namespace HotelRezervacija
{
    public partial class AdminPrijava : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPrijavi_Click(object sender, EventArgs e)
        {
            var adminPL = new PrezentacionaLogika.AdminAutentifikacija();
            string korisnickoIme = txtKorisnickoIme.Text.Trim();
            string lozinka = txtLozinka.Text.Trim();
            if (adminPL.ProveriAdmina(korisnickoIme, lozinka))
            {
                Session["KorisnickoIme"] = korisnickoIme;   // <-- ČUVAŠ U SESIJU!
                Response.Redirect("AdminUspesnaPrijava.aspx");
            }
            else
            {
                lblMessage.Text = "Pogrešno korisničko ime ili lozinka!";
                lblMessage.CssClass = "message-label error";
            }
        }

    }
}