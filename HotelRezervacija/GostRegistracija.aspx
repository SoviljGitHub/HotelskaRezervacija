<%@ Page Title="Registracija gosta" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GostRegistracija.aspx.cs" Inherits="HotelRezervacija.GostRegistracija" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="CSS/gostregistracija.css" />
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="registracija-wrap">
        <h2>Registracija gosta</h2>
        <div class="forma-registracija">
            <asp:Label ID="lblPoruka" runat="server" CssClass="poruka-label" EnableViewState="false" />
            <div class="form-group">
                <label>JMBG:</label>
                <asp:TextBox ID="txtJMBG" runat="server" CssClass="form-control" MaxLength="13" />
            </div>
            <div class="form-group">
                <label>Ime:</label>
                <asp:TextBox ID="txtIme" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label>Prezime:</label>
                <asp:TextBox ID="txtPrezime" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label>Pol:</label>
                <asp:DropDownList ID="ddlPol" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Muški" Value="Muški" />
                    <asp:ListItem Text="Ženski" Value="Ženski" />
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label>Datum rođenja:</label>
                <asp:TextBox ID="txtDatumRodjenja" runat="server" CssClass="form-control" TextMode="Date" />
            </div>
            <div class="form-group">
                <label>Broj telefona:</label>
                <asp:TextBox ID="txtBrojTelefona" runat="server" CssClass="form-control" />
            </div>
            <div class="form-group">
                <label>Email:</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" />
            </div>
            <div class="form-buttons">
                <asp:Button ID="btnRegistruj" runat="server" Text="Registruj se" CssClass="reg-btn" OnClick="btnRegistruj_Click" />
            </div>
        </div>
    </div>
</asp:Content>
