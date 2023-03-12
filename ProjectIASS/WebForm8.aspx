<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm8.aspx.cs" Inherits="ProjectIASS.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:Label ID="labelLogare" runat="server" Font-Bold="True" Font-Size="12pt" style="margin-left:30px; color:#000000"></asp:Label>
        <br /><br /><br />

        <div style="margin-left:30px">
            <asp:Label runat="server" Font-Size="12pt" style="color:#000000" Font-Bold="True" Text="Medicamentul cautat:"></asp:Label> 
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" Text="Cauta" runat="server" OnClick="Button1_Click" class="btn-primary"/> 
        </div>
        <br /><br />

        <asp:Label ID="LabelCautare" class="error" runat="server" style="margin-left:30px" Font-Size="12pt"></asp:Label>
        <br /><br />

        <asp:GridView ID="GridView1" runat="server" style="margin-left: 30px" Width="500px"></asp:GridView>
        <br /><br /><br />

        <div style="margin-left:30px">
            <asp:Label ID="Label3" runat="server"></asp:Label>
            <asp:Button ID="Button2" runat="server" text="Adauga medicament nou in baza de date" OnClick="Button2_Click" class="btn-primary"/><br /><br />
            <asp:Button ID="Button3" Text="Sterge medicament din baza de date" runat="server" OnClick="Button3_Click" OnClientClick="return confirm('Sunteti sigur ca doriti ca stergeti acest medicament?');" class="btn-primary" Visible ="false"/><br /><br />
            <asp:Button ID="Button4" Text="Completare stoc medicament" runat="server" OnClick="Button4_Click" class="btn-primary" Visible ="false"/><br /><br />
        </div>
     </form>
</asp:Content>
