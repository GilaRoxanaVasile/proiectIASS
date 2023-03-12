<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm7.aspx.cs" Inherits="ProjectIASS.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <form id="form1" runat="server">
        <asp:Label ID="labelLogare" runat="server" Font-Bold="True" Font-Size="12pt" style="margin-left:30px; color:#000000"></asp:Label>
        <br /><br /><br />

        <asp:GridView ID="GridView1" runat="server" style="margin-left:30px" Width="500px"></asp:GridView>
        <br /><br />

        <asp:Button ID="Button1" runat="server" OnClick="Button2_Click" Text="Generare PDF si trimitere mail" style="margin-left:30px" class="btn-primary"/><br />
        <asp:Label ID="Label1" runat="server" Text="Label" class="error" style="margin-left:30px"></asp:Label>
    </form>
</asp:Content>
