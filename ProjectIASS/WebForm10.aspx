<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm10.aspx.cs" Inherits="ProjectIASS.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form ID="form1" runat ="server">
        <asp:Label ID="labelLogare" runat="server" Font-Bold="True" Font-Size="12pt" style="margin-left:30px; color:#000000"></asp:Label>
        <br /><br /><br />

        <asp:Label ID="LabelEroare" runat="server" Font-Size="12pt" style="margin-left:15%"></asp:Label>
        <br /><br />
        <asp:Label runat="server" Text="Adaugare medicament" Font-Size="13pt" Font-Bold="True" style="margin-left:40%; color:#000000"></asp:Label>
        <br /><br /><br /><br />

        <div>
           <asp:Label runat="server" Text="Denumire" Font-Size="11pt"  style="margin-left:35%; color:#000000"></asp:Label>
           <asp:TextBox ID="TextBox1" runat="server" style="margin-left:35px"></asp:TextBox>
        </div><br />

        <div>
           <asp:Label runat="server" Text="Stoc" Font-Size="11pt"  style="margin-left:35%; color:#000000"></asp:Label>
           <asp:TextBox ID="TextBox2" runat="server" style="margin-left:70px"></asp:TextBox>
        </div><br /><br />

       <asp:Label ID="Label1" runat="server" class="error" Font-Size="10pt" style="margin-left:39%"></asp:Label><br />
       <asp:Button Id="Buton1" runat="server" Text="Adauga medicament" style="margin-left:40%" OnClick="Buton1_Click" class="btn-primary"/><br />

    </form>
</asp:Content>
