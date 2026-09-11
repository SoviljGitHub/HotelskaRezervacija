<%@ Page Title="Dobrodošli admin" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminUspesnaPrijava.aspx.cs" Inherits="HotelRezervacija.AdminUspesnaPrijava" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="CSS/admindobrodosao.css" />
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="admin-welcome">
        <h2>Dobrodošli, <asp:Label ID="lblKorisnickoIme" runat="server" CssClass="admin-ime" />!</h2>
        <p>Prijavljeni ste kao administrator sistema.</p>
        <div class="admin-btn-grupa">
            <asp:Button ID="btnSobe" runat="server" Text="Upravljanje sobama" CssClass="admin-btn" OnClick="btnSobe_Click" />
            <asp:Button ID="btnRezervacije" runat="server" Text="Pregled registracija" CssClass="admin-btn rezervacije-btn" OnClick="btnRezervacije_Click" />
        </div>
    </div>
</asp:Content>

