using SlojPodataka.Modeli;
using PrezentacionaLogika;
using System;
using System.Web.UI;
using System.Text.RegularExpressions;


namespace HotelRezervacija
{
    public partial class GostRegistracija : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegistruj_Click(object sender, EventArgs e)
        {
            string jmbg = txtJMBG.Text.Trim();
            string ime = txtIme.Text.Trim();
            string prezime = txtPrezime.Text.Trim();
            string pol = ddlPol.SelectedValue;
            string brojTelefona = txtBrojTelefona.Text.Trim();
            string email = txtEmail.Text.Trim();
            DateTime datumRodjenja;

            // Validacija
            if (jmbg.Length != 13 || !Regex.IsMatch(jmbg, @"^\d{13}$"))
            {
                lblPoruka.Text = "JMBG mora imati tačno 13 cifara!";
                return;
            }
            if (string.IsNullOrWhiteSpace(ime) || string.IsNullOrWhiteSpace(prezime) ||
                !DateTime.TryParse(txtDatumRodjenja.Text, out datumRodjenja))
            {
                lblPoruka.Text = "Sva polja osim broja telefona i emaila su obavezna!";
                return;
            }

            Gost noviGost = new Gost
            {
                JMBG = jmbg,
                Ime = ime,
                Prezime = prezime,
                Pol = pol,
                DatumRodjenja = datumRodjenja,
                BrojTelefona = brojTelefona,
                Email = email
            };

            GostLogika pl = new GostLogika();
            string rezultat = pl.Registruj(noviGost);

            if (rezultat == "Uspešno ste se registrovali.")
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                lblPoruka.Text = rezultat;
            }
        }

    }
}

