using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelRezervacija
{
    public partial class GostUspesnaPrijava : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string email = Session["GostEmail"] as string ?? "Nepoznat korisnik";
                lblEmail.Text = email;
            }
        }

        protected void btnPrijavaRezervacije_Click(object sender, EventArgs e)
        {
            Response.Redirect("PrijavaRezervacije.aspx");
        }

        protected void btnPregledRezervacija_Click(object sender, EventArgs e)
        {
            Response.Redirect("PregledRezervacija.aspx");
        }
    }
}
