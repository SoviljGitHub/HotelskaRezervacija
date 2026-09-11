<%@ Page Title="Upravljanje registracijama" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="UpravljanjeRegistracijama.aspx.cs"
    Inherits="HotelRezervacija.UpravljanjeRegistracijama" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="CSS/upravljanjeregistracijama.css" />
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="upravljanje-reg-wrap">
        <h2>Upravljanje registracijama</h2>

        <div class="filteri-grupa">
            <!-- Filtriranje po POLU -->
            <asp:DropDownList ID="ddlPol" runat="server" CssClass="filter-ddl" Width="160px">
                <asp:ListItem Text="Svi" Value="svi" />
                <asp:ListItem Text="Muški" Value="M" />
                <asp:ListItem Text="Ženski" Value="Z" />
            </asp:DropDownList>
            <asp:Button ID="btnFiltriraj" runat="server" Text="Filtriraj" CssClass="filter-btn" OnClick="btnFiltriraj_Click" />

            <!-- Štampa po JMBG -->
            <asp:DropDownList ID="ddlJmbgStamp" runat="server" CssClass="filter-ddl" Width="220px" />
            <asp:Button ID="btnStampaPoJmbg" runat="server" Text="Štampaj po JMBG" CssClass="stampaj-btn" OnClick="btnStampaPoJmbg_Click" />

            <!-- Štampa svih -->
            <asp:Button ID="btnStampaSve" runat="server" Text="Štampaj sve" CssClass="stampaj-btn" OnClick="btnStampaSve_Click" />
        </div>

        <asp:GridView ID="gvRegistracije" runat="server"
            CssClass="upravljanje-tabela"
            AutoGenerateColumns="False"
            DataKeyNames="JMBG"
            OnRowCommand="gvRegistracije_RowCommand">
            <Columns>
                <asp:BoundField DataField="Ime" HeaderText="Ime" />
                <asp:BoundField DataField="Prezime" HeaderText="Prezime" />
                <asp:BoundField DataField="JMBG" HeaderText="JMBG" />
                <asp:BoundField DataField="Pol" HeaderText="Pol" />
                <asp:BoundField DataField="DatumRodjenja" HeaderText="Datum rođenja" DataFormatString="{0:dd.MM.yyyy}" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Telefon" HeaderText="Telefon" />
              <asp:ButtonField ButtonType="Button" Text="Obriši"  CommandName="DeleteRegistracija" ControlStyle-CssClass="btn-delete" />

            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
