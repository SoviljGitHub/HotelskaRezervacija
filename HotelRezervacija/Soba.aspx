<%@ Page Title="Sobe" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Soba.aspx.cs" Inherits="HotelRezervacija.Soba" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" href="CSS/soba.css" />
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="soba-wrap">
        <h2>Upravljanje sobama</h2>
        <div class="form-flex">
            <div class="forma">
                <asp:HiddenField ID="hfIdSobe" runat="server" />
                <div class="form-group">
                    <label>Broj sobe:</label>
                    <asp:TextBox ID="txtBrojSobe" runat="server" CssClass="form-control" />
                </div>
                <div class="form-group">
                    <label>Tip sobe:</label>
                    <asp:TextBox ID="txtTipSobe" runat="server" CssClass="form-control" />
                </div>
                <div class="form-group">
                    <label>Kapacitet:</label>
                    <asp:TextBox ID="txtKapacitet" runat="server" CssClass="form-control" />
                </div>
                <div class="form-group">
                    <label>Cena po noći (RSD):</label>
                    <asp:TextBox ID="txtCenaPoNoci" runat="server" CssClass="form-control" />
                </div>
                <div class="btn-row">
                    <asp:Button ID="btnDodaj" runat="server" Text="Dodaj" CssClass="btn primary" OnClick="btnDodaj_Click" />
                    <asp:Button ID="btnIzmeni" runat="server" Text="Sačuvaj izmene" CssClass="btn warning" OnClick="btnIzmeni_Click" Visible="false" />
                    <asp:Button ID="btnReset" runat="server" Text="Resetuj" CssClass="btn secondary" OnClick="btnReset_Click" />
                </div>
                <asp:Label ID="lblPoruka" runat="server" CssClass="message-label" EnableViewState="false" />
            </div>
            <div class="tabela">
                <asp:GridView ID="gvSobe" runat="server" AutoGenerateColumns="False" CssClass="sobe-tabela"
                    DataKeyNames="Id"
                    OnRowCommand="gvSobe_RowCommand"
                    OnRowDeleting="gvSobe_RowDeleting"
                    AllowPaging="true"
                    PageSize="8"
                    OnPageIndexChanging="gvSobe_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="BrojSobe" HeaderText="Broj sobe" />
                        <asp:BoundField DataField="TipSobe" HeaderText="Tip sobe" />
                        <asp:BoundField DataField="Kapacitet" HeaderText="Kapacitet" />
                        <asp:BoundField DataField="CenaPoNoci" HeaderText="Cena (RSD)" DataFormatString="{0:N2}" />
                        <asp:ButtonField Text="Izmeni" CommandName="IzmeniRed" ButtonType="Button" />
                        <asp:ButtonField Text="Obriši" CommandName="Delete" ButtonType="Button" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
