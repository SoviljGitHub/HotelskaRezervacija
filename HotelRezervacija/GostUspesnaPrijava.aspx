<%@ Page Title="Dobrodošli gost" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GostUspesnaPrijava.aspx.cs" Inherits="HotelRezervacija.GostUspesnaPrijava" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="CSS/gostuspesna.css" />
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="gost-uspesno-wrap">
        <h2>Dobrodošli, <asp:Label ID="lblEmail" runat="server" CssClass="gost-imejl" />!</h2>
        <p>Hvala što koristite naše usluge. Izaberite željenu opciju:</p>
        <div class="gost-btn-grupa">
            <asp:Button ID="btnPrijavaRezervacije" runat="server" Text="Prijavi rezervaciju" CssClass="gost-btn" OnClick="btnPrijavaRezervacije_Click" />
            <asp:Button ID="btnPregledRezervacija" runat="server" Text="Pregled rezervacija" CssClass="gost-btn pregled-btn" OnClick="btnPregledRezervacija_Click" />
        </div>
    </div>
</asp:Content>
