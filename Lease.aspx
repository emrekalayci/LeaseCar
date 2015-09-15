<%@ Page Title="Lease Car" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Lease.aspx.cs" Inherits="TermProject.Lease" %>
<%@ MasterType VirtualPath="~/Main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <div style="margin-bottom:80px"></div>
    <table class="table table-bordered" style="text-decoration:none;margin-bottom:60px">
        <thead>
        <tr>
            <th>Driver</th>
            <th>Score</th>
            <th>Vehicle</th>
            <th>Daily Cost</th>
        </tr>
        </thead>
        <tbody>
            <tr>
                <td><asp:Label ID="lblDriver" runat="server" Text="DriverName"></asp:Label></td>
                <td><asp:Label ID="lblScore" runat="server" Text="Score"></asp:Label></td>
                <td><asp:Label ID="lblModel" runat="server" Text="Model"></asp:Label></td>
                <td><asp:Label ID="lblCost" runat="server" Text="Cost"></asp:Label></td>
            </tr>
        </tbody>
     </table>
    <div class="form-group">
        <div style="display:inline-block;margin-right:40px;">
            <b>Start Date</b>
            <asp:Calendar ID="clStartDate" runat="server"></asp:Calendar>
        </div>
        <div style="display:inline-block">
            <b>End Date</b>
            <asp:Calendar ID="clEndDate" runat="server"></asp:Calendar>
        </div>
    </div>
    <div class="form-group">
        <b>Description</b>
        <asp:TextBox ID="txtDescription" TextMode="multiline" Columns="30" Rows="5" CssClass="form-control" runat="server"  />
    </div>
    <div class="form-group">
        <asp:Button ID="btnPay" runat="server" Text="Pay" OnClick="btnPay_Click" CssClass="btn btn-primary" />
    </div>
    <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
