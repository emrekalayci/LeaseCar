<%@ Page Title="Cancellation" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Cancel.aspx.cs" Inherits="TermProject.Cancel" %>
<%@ MasterType VirtualPath="~/Main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <div style="margin-bottom:80px"></div>
    <div style="width:500px;margin: 0 auto;position:relative;text-align:center">
     <asp:Panel ID="pnlSuccess" runat="server">
        <div class="alert alert-success" role="alert">
            <span class="glyphicon glyphicon-ok" aria-hidden="true"></span>
            <asp:Label ID="lblSuccess" runat="server" Text="Label"></asp:Label>
        </div>
     </asp:Panel>
     <asp:Panel ID="pnlError" runat="server">
        <div class="alert alert-danger" role="alert">
            <span class="glyphicon glyphicon-info-sign" aria-hidden="true"></span>
            <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
        </div>
     </asp:Panel>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
