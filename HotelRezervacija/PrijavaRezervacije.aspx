<%@ Page Title="Prijava rezervacije" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PrijavaRezervacije.aspx.cs" Inherits="HotelRezervacija.PrijavaRezervacije" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="CSS/prijavarezervacije.css" />
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="rezervacija-wrap">
        <h2>Prijava rezervacije</h2>
        <div class="forma-rezervacija">
            <asp:Label ID="lblPoruka" runat="server" CssClass="poruka-label" EnableViewState="false" />
            <div class="form-group">
                <label>JMBG gosta:</label>
                <asp:TextBox ID="txtJMBG" runat="server" CssClass="form-control" MaxLength="13" />
            </div>
            <div class="form-group">
                <label>Broj sobe:</label>
                <asp:DropDownList ID="ddlBrojSobe" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label>Datum prijave:</label>
                <asp:TextBox ID="txtDatumPrijave" runat="server" CssClass="form-control" TextMode="Date" />
            </div>
            <div class="form-group">
                <label>Datum odjave:</label>
                <asp:TextBox ID="txtDatumOdjave" runat="server" CssClass="form-control" TextMode="Date" />
            </div>
            <div class="form-buttons">
                <asp:Button ID="btnRezervisi" runat="server" Text="Rezerviši" CssClass="rezervisi-btn" OnClick="btnRezervisi_Click" />
            </div>
        </div>
    </div>
</asp:Content>
