<%@ Page Title="Edit Profile" Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="EditProfile.aspx.cs" Inherits="TermProject.EditProfile" %>
<%@ MasterType VirtualPath="~/Main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
    <link href="Content/signin.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <div class="form-signin">
        <asp:Label ID="lblInfo" runat="server" Text="Label"></asp:Label>
        <h3 class="form-signin-heading"></h3>
        <div class="form-group">
            <label for="inputEmail">Ad Soyad:</label>
            <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="inputEmail">Phone Number:</label>
            <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="inputEmail">Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <asp:Button ID="btnEdit" runat="server" Text="Update" OnClick="btnEdit_Click" CssClass="btn btn-lg btn-primary btn-block" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>

