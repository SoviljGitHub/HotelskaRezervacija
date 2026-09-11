<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HotelRezervacija._Default" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="CSS/pocetna.css" />
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <div class="pocetna-wrap">
    <div class="pocetna-info">
        <h1>Dobrodošli u <span class="hotel-naziv">Luxury Hotel</span>!</h1>
        <p>
            Naš hotel pruža vrhunski komfor i luksuz za sve goste.<br />
            Uživajte u elegantnim sobama, vrhunskoj ishrani, spa centru, fitnesu i personalizovanoj usluzi.<br />
            <b>Posebna pogodnost:</b> Rezervišite više od 7 dana i ostvarite popust!
        </p>
        <ul class="ponuda-lista">
            <li>✓ Moderan wellness & spa centar</li>
            <li>✓ Restoran i bogat doručak</li>
            <li>✓ Besplatan Wi-Fi i parking</li>
            <li>✓ 24/7 recepcija</li>
        </ul>
        <a href="GostRegistracijaPrijava.aspx" class="pocetna-prijava-btn">Prijavi se kao gost</a>
    </div>
    <div class="pocetna-img">
        <img src="Slike/pocetna.jpg" alt="Hotel Slika" />
    </div>
</div>


</asp:Content>
