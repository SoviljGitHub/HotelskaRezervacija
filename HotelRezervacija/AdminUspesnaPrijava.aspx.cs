using System;
using System.Web.UI;

namespace HotelRezervacija
{
    public partial class AdminUspesnaPrijava : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Preuzmi korisničko ime iz sesije ili postavi default vrednost
                string korisnickoIme = Session["KorisnickoIme"] as string ?? "admin";
                lblKorisnickoIme.Text = korisnickoIme;
            }
        }

        protected void btnSobe_Click(object sender, EventArgs e)
        {
            Response.Redirect("Soba.aspx");
        }

        protected void btnRezervacije_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpravljanjeRegistracijama.aspx");
        }
    }
}
