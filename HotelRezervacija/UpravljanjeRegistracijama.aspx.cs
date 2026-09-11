using PrezentacionaLogika;
using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelRezervacija
{
    public partial class UpravljanjeRegistracijama : Page
    {
        private readonly GostLogika _gostLogika = new GostLogika();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UcitajRegistracije();   
                UcitajJmbgZaStampu();
            }
        }

        // ⇩⇩ NOVO: robusna normalizacija pola na M/Z (hvata Muški/Ženski, Muski/Zenski, m/ž itd.)
        private static string NormalizujPol(object vrednost)
        {
            var pol = Convert.ToString(vrednost ?? "").Trim();
            if (pol.Length == 0) return "";
            var first = pol.Substring(0, 1).ToUpperInvariant();
            if (first == "M") return "M";
            if (first == "Z" || first == "Ž") return "Z";
            return "";
        }

        private void UcitajRegistracije(string polFilter = "svi")
        {
            DataTable dt = _gostLogika.VratiSveGoste();

            // Normalizuj/obezbedi kolonu Pol
            if (!dt.Columns.Contains("Pol"))
                dt.Columns.Add("Pol", typeof(string));

            foreach (DataRow r in dt.Rows)
                r["Pol"] = NormalizujPol(r["Pol"]);

            // Filtriranje po polu (M/Z)
            if (polFilter == "M" || polFilter == "Z")
            {
                var q = dt.AsEnumerable()
                          .Where(r => NormalizujPol(r["Pol"]) == polFilter);
                dt = q.Any() ? q.CopyToDataTable() : dt.Clone();
            }

            // Trimovana kolona za pouzdano poređenje JMBG (CHAR(13) zna da ima razmake)
            if (!dt.Columns.Contains("JMBGTrim"))
                dt.Columns.Add("JMBGTrim", typeof(string));
            foreach (DataRow r in dt.Rows)
                r["JMBGTrim"] = Convert.ToString(r["JMBG"] ?? "").Trim();

            // u Session ide već pripremljen set (sa Pol i JMBGTrim)
            Session["RegDT"] = dt.Copy();

            gvRegistracije.DataSource = dt;
            gvRegistracije.DataBind();
        }

        private void UcitajJmbgZaStampu()
        {
            var dt = _gostLogika.VratiSveGoste();

            ddlJmbgStamp.Items.Clear();

            var stavke = dt.AsEnumerable()
                           .Select(r => new
                           {
                               Jmbg = (r["JMBG"] ?? "").ToString().Trim(),
                               Ime = (r["Ime"] ?? "").ToString().Trim(),
                               Prezime = (r["Prezime"] ?? "").ToString().Trim()
                           })
                           .Where(x => !string.IsNullOrEmpty(x.Jmbg))
                           .Distinct()
                           .OrderBy(x => x.Prezime)
                           .ThenBy(x => x.Ime)
                           .ToList();

            foreach (var s in stavke)
                ddlJmbgStamp.Items.Add(new ListItem($"{s.Prezime} {s.Ime} – {s.Jmbg}", s.Jmbg));
        }

        protected void btnFiltriraj_Click(object sender, EventArgs e)
        {
            UcitajRegistracije(ddlPol.SelectedValue);
        }

        protected void gvRegistracije_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRegistracija")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                string jmbg = gvRegistracije.DataKeys[index].Value.ToString();

                bool ok = _gostLogika.ObrisiGosta(jmbg);

                UcitajRegistracije(ddlPol.SelectedValue);
            }
        }

        protected void btnStampaSve_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "printAll", "window.print();", true);
        }

        protected void btnStampaPoJmbg_Click(object sender, EventArgs e)
        {
            string izabraniJmbg = ddlJmbgStamp.SelectedValue?.Trim();
            if (string.IsNullOrEmpty(izabraniJmbg)) return;

            var dtAll = Session["RegDT"] as DataTable;
            if (dtAll == null)
            {
                UcitajRegistracije(ddlPol.SelectedValue);
                dtAll = Session["RegDT"] as DataTable;
            }

            // filtriraj po JMBG (trim varijanta)
            var q = dtAll.AsEnumerable()
                         .Where(r => Convert.ToString(r["JMBGTrim"]) == izabraniJmbg);

            DataTable dtZaStampu = q.Any() ? q.CopyToDataTable() : dtAll.Clone();

            gvRegistracije.DataSource = dtZaStampu;
            gvRegistracije.DataBind();

            ClientScript.RegisterStartupScript(this.GetType(), "printOne", "window.print();", true);

            
        }

    }
}
