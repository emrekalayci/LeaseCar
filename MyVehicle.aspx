<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="MyVehicle.aspx.cs" Inherits="TermProject.MyVehicle" %>
<%@ MasterType VirtualPath="~/Main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
    <link href="Content/signin.css" rel="stylesheet">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
        <div class="form-signin" style="margin-top:30px;">
            <asp:Label ID="lblInfo" runat="server" EnableTheming="False">
        </asp:Label>
        <div class="form-group">
            <label for="inputEmail">Model</label>
            <asp:TextBox ID="txtModel" runat="server" CssClass="form-control"/>
        </div>
        <div class="form-group">
            <label for="inputEmail">Year</label>
            <asp:TextBox ID="txtYear" runat="server" CssClass="form-control"/>
        </div>
        <div class="form-group">
            <label for="inputPassword">User Name</label>
            <asp:TextBox ID="txtLicenseNumber" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label for="inputPassword">Phone Number</label>
            <asp:TextBox ID="txtCity" runat="server" CssClass="form-control"/>
        </div>
        <div class="form-group">
            <label for="inputPassword">Daily Cost (₺)</label>
            <asp:TextBox ID="txtCost" runat="server" CssClass="form-control"/>
        </div>

        <asp:Button Text="Save" ID="btnAdd" OnClick="btnAddVehicle_Click" runat="server" CssClass="btn btn-lg btn-primary btn-block" />        
        <asp:Button Text="Update" ID="btnUpdate" OnClick="btnUpdateVehicle_Click" runat="server" CssClass="btn btn-lg btn-primary btn-block" />        
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
