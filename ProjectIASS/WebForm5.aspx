<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm5.aspx.cs" Inherits="ProjectIASS.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:Label ID="labelLogare" runat="server" Font-Bold="True" Font-Size="12pt" style="margin-left:30px; color:#000000"></asp:Label>
        <br /><br /><br />
        <div style="margin-left:30px">
            <asp:Label runat="server" Font-Size="12pt" style="color:#000000" Font-Bold="True" Text="Numele cautat:"></asp:Label> 
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" Text="Cauta" runat="server" OnClick="Button1_Click" class="btn-primary"/> 
        </div>
        <br /><br /><br />

        <asp:Label ID="LabelCautare" class="error" runat="server" style="margin-left:30px" Font-Size="12pt"></asp:Label>
        <br /><br /><br />

        <asp:GridView ID="GridView1" runat="server" style="margin-left:30px" Width="700px"></asp:GridView>
        <br /><br /><br />

        <div style="margin-left:30px">
            <asp:Button ID="Button3" class="btn-primary" runat="server" text="Adaugare pacient nou in baza de date" OnClick="Button3_Click"/><br /><br />
            <asp:Button ID="Button2" class="btn-primary" Text="Vezi reteta pacientului" runat="server" OnClick="Button2_Click" Visible="false"/><br /><br />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Generare fisier XML" class="btn-primary" Visible="false"/><br /><br />
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Stergere pacient" OnClientClick="return confirm('Sunteti sigur ca doriti ca stergeti acest pacient?');" class="btn-primary" Visible="false"/><br /><br />
        </div>
    </form>
</asp:Content>
