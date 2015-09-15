<%@ Page Title="Payment Completed" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="PaymentCompleted.aspx.cs" Inherits="TermProject.PaymentCompleted" %>
<%@ MasterType VirtualPath="~/Main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <div style="margin-bottom:80px"></div>
    <div style="width:500px;margin: 0 auto;position:relative;text-align:center">
    <div class="alert alert-success" role="alert">
        <span class="glyphicon glyphicon-ok" aria-hidden="true"></span> Your payment has been done successfully.
     </div>
    <asp:Label ID="lblInfo" runat="server" Text="Label"></asp:Label>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>