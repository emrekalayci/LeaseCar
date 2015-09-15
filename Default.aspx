<%@ Page Title="Home" Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="Default.aspx.cs" Inherits="TermProject.Default" %>
<%@ MasterType VirtualPath="~/Main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
    <link href="/Assets/Css/signin.css" rel="stylesheet">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <asp:Panel ID="pnlWelcome" runat="server">
        <!-- Welcome page for guest -->
        <div class="form-signin">
            <h2 class="form-signin-heading">Log In to Leasecar</h2>
            <label for="inputEmail" class="sr-only">User Name</label>
            <asp:TextBox runat="server" ID="txtUserName"  CssClass="form-control username" PlaceHolder="Username"></asp:TextBox>
            <label for="inputPassword" class="sr-only">Password</label>
            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password"  CssClass="form-control" PlaceHolder="Password"></asp:TextBox>
            <asp:Button Text="Sign in" ID="btnSignIn" OnClick="btnSignIn_Click" runat="server" CssClass="btn btn-lg btn-primary btn-block" />
        </div>
        <center><a href="SignUp.aspx"><b>Sign up for Leasecar</b></a></center>
    </asp:Panel>
    <asp:Panel ID="pnlHome" runat="server">
        <div style="margin-top:40px;"></div>
        <!-- Customized page for logged in user -->    
        <asp:Panel ID="pnlPassanger" runat="server">
            <div style="display:inline-block" class="col-xs-4">
                <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" PlaceHolder="Search city..."></asp:TextBox>
            </div>
            <div style="display:inline-block">
                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-default" OnClick="btnSearch_Click" />
            </div>
            <h2>Upcoming Rides</h2>
            <table class="table table-bordered" style="text-decoration:none;margin-bottom:60px">
            <thead>
            <tr>
                <th>Start Date</th>
                <th>Driver</th>
                <th>Vehicle</th>
                <th>Cancel</th>
            </tr>
            </thead>
            <tbody>
            <asp:Repeater ID="rptUpcomingRides" runat="server">
                <ItemTemplate>
                    <tr>
                      <td><%# string.Format("{0:ddd, d MMM yyyy}", Eval("StartDate"))%></td>
                      <td><%#Eval("FullName") %></td>
                      <td><%#Eval("Model") %></td>
                      <td><a href="Cancel.aspx?id=<%#Eval("Id") %>" class="btn btn-danger btn-xs">Cancel</a></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            </tbody>
            </table>

            <h2>Recent Rides</h2>
            <table class="table table-bordered" style="text-decoration:none;">
            <thead>
            <tr>
                <th>Date</th>
                <th>Driver</th>
                <th>Vehicle</th>
                <th>Review</th>
            </tr>
            </thead>
            <tbody>
            <asp:Repeater ID="rptRecentRides" runat="server">
                <ItemTemplate>
                    <tr>
                      <td><%# string.Format("{0:ddd, d MMM yyyy}", Eval("StartDate"))%></td>
                      <td><%#Eval("FullName") %></td>
                      <td><%#Eval("Model") %></td>
                      <td><a href="AddReview.aspx?id=<%#Eval("Id") %>" class="btn btn-primary btn-xs">Add review</a></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            </tbody>
            </table>
        </asp:Panel>


        <asp:Panel ID="pnlDriver" runat="server">
            <a class="btn btn-primary btn-sm" href="/MyVehicle.aspx" role="button"><span class="glyphicon glyphicon-edit" aria-hidden="true"></span> My Vehicle</a>
            <h2>Dashboard</h2>
            <table class="table table-bordered" style="text-decoration:none;margin-top:20px;">
            <thead>
            <tr>
                <th>Driver</th>
                <th>Rating</th>
                <th>Total Rides</th>
                <th>Total Income</th>
            </tr>
            </thead>
            <tbody>
                <tr>
                    <td><asp:Label ID="lblDriverName" runat="server" Text=""></asp:Label></td>
                    <td><asp:Label ID="lblRating" runat="server" Text=""></asp:Label></td>
                    <td><asp:Label ID="lblRides" runat="server" Text=""></asp:Label></td>
                    <td><asp:Label ID="lblIncome" runat="server" Text=""></asp:Label>₺</td>
                </tr>
            </tbody>
            </table>
            <div style="margin-top:40px"></div>
            <h2>Upcoming Rides</h2>
            <table class="table table-bordered" style="text-decoration:none;margin-bottom:60px">
            <thead>
            <tr>
                <th>Start Date</th>
                <th>Passanger</th>
                <th>Description</th>
            </tr>
            </thead>
            <tbody>
            <asp:Repeater ID="rptDriverUpcomingRides" runat="server">
                <ItemTemplate>
                    <tr>
                      <td><%# string.Format("{0:ddd, d MMM yyyy}", Eval("StartDate"))%></td>
                      <td><%#Eval("FullName") %></td>
                      <td><%#Eval("Description") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            </tbody>
            </table>
        </asp:Panel>
    </asp:Panel>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>