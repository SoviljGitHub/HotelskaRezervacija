<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPrijava.aspx.cs" Inherits="HotelRezervacija.AdminPrijava" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="CSS/admin.css" />
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="login-wrap">
        <h2>Prijava administratora</h2>
        <div class="login-form">
            <asp:Label ID="lblMessage" runat="server" CssClass="message-label" EnableViewState="false" />
            <div class="form-group">
                <asp:Label ID="lblKorisnickoIme" runat="server" AssociatedControlID="txtKorisnickoIme" Text="Korisničko ime:" />
                <asp:TextBox ID="txtKorisnickoIme" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <asp:Label ID="lblLozinka" runat="server" AssociatedControlID="txtLozinka" Text="Lozinka:" />
                <asp:TextBox ID="txtLozinka" runat="server" CssClass="form-control" TextMode="Password" />
            </div>
            <asp:Button ID="btnPrijavi" runat="server" Text="Prijavi se" CssClass="login-btn" OnClick="btnPrijavi_Click" />
        </div>
    </div>
</asp:Content>

