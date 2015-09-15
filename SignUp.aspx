<%@ Page Title="Sign up for LeaseCar" Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="SignUp.aspx.cs" Inherits="TermProject.SignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
    <link href="Content/signin.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <div class="form-signin">
        <asp:Label ID="infoLabel" runat="server" EnableTheming="False">
        </asp:Label>

        <h2 class="form-signin-heading">Sign up for Leasecar</h2>
        <div class="form-group">
            <label for="inputEmail" class="sr-only">Name Surname</label>
            <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" PlaceHolder="Name Surname"/>
        </div>
        <div class="form-group">
            <label for="inputEmail" class="sr-only">Email address</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" PlaceHolder="Email"/>
        </div>
       <!-- <div class="form-group">
            <label for="inputPassword" class="sr-only">Confirm Password</label>
            <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" style="display:inline-block" PlaceHolder="Confirm Password"/>
            <asp:CompareValidator ForeColor="Red" ID="CompareValidor_password" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" runat="server" ErrorMessage="Passwords do not match" BorderStyle="Outset">*</asp:CompareValidator></td>    
        </div>-->
        <div class="form-group">
            <label for="inputPassword" class="sr-only">User Name</label>
            <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" PlaceHolder="User Name"/>
        </div>
        <div class="form-group">
            <label for="inputPassword" class="sr-only">Phone Number</label>
            <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control" PlaceHolder="Phone Number"/>
        </div>
        <div class="form-group">
            <label for="inputPassword" class="sr-only">Password</label>
            <asp:TextBox ID="txtPassword" TextMode="password" runat="server" CssClass="form-control" PlaceHolder="Password"/>
        </div>
        <asp:RadioButtonList ID="radiobtnUserType" runat="server" Width="194px" EnableTheming="False">   
            <asp:ListItem Value="1">Passanger</asp:ListItem> 
            <asp:ListItem Value="2">Driver</asp:ListItem>
        </asp:RadioButtonList>

        <asp:Button Text="Sign Up" ID="buttonSignup" OnClick="buttonSignup_Click" runat="server" CssClass="btn btn-lg btn-primary btn-block" />        
    </div>
    <center><a href="Default.aspx"><b>Have already account? Sign In</b></a></center>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
