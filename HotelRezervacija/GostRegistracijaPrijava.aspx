<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GostRegistracijaPrijava.aspx.cs" Inherits="HotelRezervacija.GostRegistracijaPrijava" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="CSS/gost.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="gost-wrap">
        <h2>Hvala vam što koristite usluge <span class="hotel-naziv">Luxury Hotela</span>!</h2>
        <p class="gost-info">
            Izaberite jednu od opcija ispod kako biste nastavili:
        </p>
        <div class="gost-btn-group">
            <a href="GostRegistracija.aspx" class="gost-btn">Registruj se</a>
            <a href="GostPrijava.aspx" class="gost-btn secondary">Prijavi se</a>
        </div>
    </div>
</asp:Content>
