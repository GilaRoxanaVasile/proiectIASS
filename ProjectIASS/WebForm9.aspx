﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm9.aspx.cs" Inherits="ProjectIASS.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <form ID="form1" runat ="server">
        <asp:Label ID="labelLogare" runat="server" Font-Bold="True" Font-Size="12pt" style="margin-left:30px; color:#000000"></asp:Label>
        <br /><br /><br />
        
        <asp:Label ID="LabelEroare" runat="server"></asp:Label>
        <br /><br />
        <asp:Label runat="server" Text="Modificare stoc" Font-Size="13pt" Font-Bold="True" style="margin-left:40%; color:#000000"></asp:Label>
        <br /><br /><br /><br />

        <div>
           <asp:Label runat="server" Text="Introduceti noul stoc" Font-Size="11pt"  style="margin-left:35%; color:#000000"></asp:Label>
           <asp:TextBox ID="TextBox1" runat="server" style="margin-left:35px"></asp:TextBox>
        </div><br /><br />

        <asp:Label ID="Label1" runat="server" Font-Size="11pt" style="margin-left:41%" class="error"></asp:Label><br />
        <asp:Button Id="Buton1" runat="server" Text="Modifica" style="margin-left:45%" OnClick="Buton1_Click" class="btn-primary"/>
    </form>
</asp:Content>
