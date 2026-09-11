<%@ Page Title="Pregled rezervacija" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PregledRezervacija.aspx.cs" Inherits="HotelRezervacija.PregledRezervacija" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="CSS/pregledrezervacije.css" />
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="pregled-rezervacija-wrap">
        <h2>Pregled rezervacija</h2>
        <asp:GridView ID="gvRezervacije" runat="server" CssClass="rezervacije-tabela" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="JMBG" HeaderText="JMBG gosta" />
                <asp:BoundField DataField="BrojSobe" HeaderText="Broj sobe" />
                <asp:BoundField DataField="DatumPrijave" HeaderText="Datum prijave" DataFormatString="{0:dd.MM.yyyy}" />
                <asp:BoundField DataField="DatumOdjave" HeaderText="Datum odjave" DataFormatString="{0:dd.MM.yyyy}" />
                <asp:BoundField DataField="Cena" HeaderText="Ukupna cena (RSD)" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="Popust" HeaderText="Popust (%)" />
            </Columns>
        </asp:GridView>
        <div class="print-btn-container">
              <asp:Label ID="lblPoruka" runat="server" EnableViewState="false" />
            <asp:Button ID="btnStampaj" runat="server" Text="Štampaj tabelu" CssClass="print-btn" OnClick="btnStampaj_Click" />
        </div>
    </div>
</asp:Content>
