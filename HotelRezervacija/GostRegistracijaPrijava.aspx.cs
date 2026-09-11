using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelRezervacija
{
    public partial class GostRegistracijaPrijava : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegistracija_Click(object sender, EventArgs e)
        {
            Response.Redirect("GostRegistracija.aspx");
        }

        protected void btnPrijava_Click(object sender, EventArgs e)
        {
            Response.Redirect("GostPrijava.aspx");
        }
    }
}