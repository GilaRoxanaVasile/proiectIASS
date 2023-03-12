<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="ProjectIASS.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:Label ID="labelLogare" runat="server" Font-Bold="True" Font-Size="12pt" style="margin-left:30px; color:#000000"></asp:Label>
        <br /><br /><br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" style="margin-left:30px" Text="Completeaza chestionar despre aplicatie" class="btn-primary"/><br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="margin-left:30px" Text="Completeaza chestionar despre clienti" class="btn-primary"/>
        <br />
        <br />
    </form>
</asp:Content>
