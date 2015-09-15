<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.Master" CodeBehind="SearchResults.aspx.cs" Inherits="TermProject.SearchResults" %>
<%@ MasterType VirtualPath="~/Main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
    <link href="Content/signin.css" rel="stylesheet">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <div style="margin-bottom:80px"></div>
    <h2>Search Results</h2>
    <table class="table table-bordered" style="text-decoration:none;margin-bottom:60px">
    <thead>
    <tr>
        <th>Driver</th>
        <th>Vehicle</th>
        <th>Daily Cost</th>
        <th>Lease</th>
    </tr>
    </thead>
    <tbody>
    <asp:Repeater ID="rptSearchResult" runat="server">
        <ItemTemplate>
            <tr>
                <td><%#Eval("FullName") %></td>
                <td><%#Eval("Model") %></td>
                <td><%#Eval("Cost") %></td>
                <td><a href="Lease.aspx?id=<%#Eval("Id") %>" class="btn btn-primary btn-xs">Lease</a></td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
    </tbody>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>

