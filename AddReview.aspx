<%@ Page Title="Add Review" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AddReview.aspx.cs" Inherits="TermProject.AddReview" %>
<%@ MasterType VirtualPath="~/Main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="StyleSection" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSection" runat="server">
    <div style="margin-bottom:80px"></div>
    <table class="table table-bordered" style="text-decoration:none;margin-bottom:60px">
    <thead>
    <tr>
        <th>Driver</th>
        <th>Vehicle</th>
        <th>Daily Cost</th>
        <th>Start Date</th>
        <th>End Date</th>
    </tr>
    </thead>
    <tbody> 
        <td><asp:Label ID="lblDriverName" runat="server" Text="DriverName"></asp:Label></td>
        <td><asp:Label ID="lblModel" runat="server" Text="Model"></asp:Label></td>
        <td><asp:Label ID="lblCost" runat="server" Text="Cost"></asp:Label></td>
        <td><asp:Label ID="lblStartDate" runat="server" Text="StartDate"></asp:Label></td>
        <td><asp:Label ID="lblEndDate" runat="server" Text="EndDate"></asp:Label></td>
      </tbody>
    </table>     

    <b>Vote</b>
    <asp:RadioButtonList ID="rblVote" runat="server" EnableTheming="False" Class="list-inline" RepeatLayout="OrderedList">
        <asp:ListItem>5</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>1</asp:ListItem>
    </asp:RadioButtonList>

    <b>Review</b>
    <asp:TextBox ID="txtComment" TextMode="multiline" Columns="30" Rows="5" CssClass="form-control" runat="server" />
    <div style="margin-top:10px;margin-bottom:10px">
        <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" CssClass="btn btn-primary" />
        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="btn btn-primary" />
    </div>
    <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptSection" runat="server">
</asp:Content>
