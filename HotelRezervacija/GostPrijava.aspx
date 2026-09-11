<%@ Page Title="Prijava gosta" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GostPrijava.aspx.cs" Inherits="HotelRezervacija.GostPrijava" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="CSS/gostprijava.css" />
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="prijava-wrap">
        <h2>Prijava gosta</h2>
        <div class="forma-prijava">
            <asp:Label ID="lblPoruka" runat="server" CssClass="poruka-label" EnableViewState="false" />
            <div class="form-group">
                <label for="txtJMBG">JMBG:</label>
                <asp:TextBox ID="txtJMBG" runat="server" CssClass="form-control" MaxLength="13" />
            </div>
            <div class="form-group">
                <label for="txtEmail">Email:</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" />
            </div>
            <div class="form-buttons">
                <asp:Button ID="btnPrijavi" runat="server" Text="Prijavi se" CssClass="prijava-btn" OnClick="btnPrijavi_Click" />
            </div>
        </div>
    </div>
</asp:Content>
