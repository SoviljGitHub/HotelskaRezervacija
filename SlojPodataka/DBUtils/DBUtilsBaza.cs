using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class DBUtilsBaza
{
    // Putanja do konekcije definisana u Web.config fajlu
    protected readonly string putanjaKonekcije = ConfigurationManager.ConnectionStrings["HotelCS"].ConnectionString;

    // Rečnik parametara za SQL upite ili procedure
    protected Dictionary<string, object> Parametri = new Dictionary<string, object>();

    // Izvršava upit koji vraća jednu vrednost (npr. COUNT, SUM, MAX...)
    protected string SaDboPrefiksom(string ime)
    {
        return ime.StartsWith("dbo.") ? ime : "dbo." + ime;
    }
    protected object IzvrsiSkalar(string upit)
    {
        using (SqlConnection konekcija = new SqlConnection(putanjaKonekcije))
        using (SqlCommand komanda = new SqlCommand(upit, konekcija))
        {
            // Ako počinje sa SELECT, tretiraj kao običan SQL tekst
            komanda.CommandType = upit.TrimStart().StartsWith("SELECT", StringComparison.OrdinalIgnoreCase)
                ? CommandType.Text
                : CommandType.StoredProcedure;

            foreach (var par in Parametri)
            {
                komanda.Parameters.AddWithValue(par.Key, par.Value ?? DBNull.Value);
            }

            konekcija.Open();
            return komanda.ExecuteScalar();
        }
    }



    // Izvršava upit koji ne vraća rezultate (npr. INSERT, UPDATE, DELETE)
    protected int IzvrsiBezRezultata(string upit)
    {
        using (SqlConnection konekcija = new SqlConnection(putanjaKonekcije))
        using (SqlCommand komanda = new SqlCommand(upit, konekcija))
        {
            komanda.CommandType = CommandType.StoredProcedure; // ← OVO DODAJ

            foreach (var par in Parametri)
            {
                komanda.Parameters.AddWithValue(par.Key, par.Value);
            }

            konekcija.Open();
            return komanda.ExecuteNonQuery();
        }
    }


    // Izvršava skladištenu proceduru i vraća rezultate kao DataTable
    protected DataTable IzvrsiCitanje(string nazivProcedure)
    {
        using (SqlConnection konekcija = new SqlConnection(putanjaKonekcije))
        using (SqlCommand komanda = new SqlCommand(nazivProcedure, konekcija))
        {
            komanda.CommandType = CommandType.StoredProcedure;

            foreach (var par in Parametri)
            {
                komanda.Parameters.AddWithValue(par.Key, par.Value);
            }

            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataTable tabela = new DataTable();
            adapter.Fill(tabela);
            return tabela;
        }
    }
    // Izvršava običan SELECT upit i vraća rezultate kao DataTable
    protected DataTable IzvrsiCitanjeQuery(string upit)
    {
        using (SqlConnection konekcija = new SqlConnection(putanjaKonekcije))
        using (SqlCommand komanda = new SqlCommand(upit, konekcija))
        {
            foreach (var par in Parametri)
            {
                komanda.Parameters.AddWithValue(par.Key, par.Value);
            }

            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataTable tabela = new DataTable();
            adapter.Fill(tabela);
            return tabela;
        }
    }
    protected object IzvrsiSkalarStoredProcedure(string nazivProcedure)
    {
        using (SqlConnection konekcija = new SqlConnection(putanjaKonekcije))
        using (SqlCommand komanda = new SqlCommand(nazivProcedure, konekcija))
        {
            komanda.CommandType = CommandType.StoredProcedure;

            foreach (var par in Parametri)
            {
                komanda.Parameters.AddWithValue(par.Key, par.Value);
            }

            konekcija.Open();
            return komanda.ExecuteScalar();
        }
    }




}
