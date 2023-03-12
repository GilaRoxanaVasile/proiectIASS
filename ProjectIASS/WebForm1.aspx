<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ProjectIASS.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="css/my.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="my.css">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Autentificare</title>
	<link rel="stylesheet" type="text/css" href="css/bootstrap.css" />

</head>

    <body background="Imagini/back1.jpg" style="height: 660px" id="login">
     <main>
      <div class="box">
        <div class="inner-box">
        
            <form id="form1" runat="server" class="form-principal">
                   
              <div  class="logo">
                <img src="Imagini/logo.png" style="height:100px; width:110px" alt="easyclass" />
                  <br /> 
                  <br /> 
                   <br /> 
                  <br />
                   <br /> 
                  <br /> 
                   <br /> 
                  <br /> 
                  <br /> 
                   <br /> 
                  <br />
                  <br />
                <h2 style="color:#16a085">OnlineFarm</h2>
              </div>
                <h4 style="margin-left:80px; color:#16a085";>Bine ati venit!</h4>
               
                <br /><br />
             <div style="width: 290px; height: 345px;  id="div">

            

          

            <asp:Label ID="Label1" runat="server" Text="Utilizator"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" Height="25px" Width="250px" >
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Parola"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <br />
            <asp:TextBox ID="TextBox1" runat="server" Height="25px" TextMode="Password" Width="250px" ></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" class="error"></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" Height="25px" Text="Autentificare" Width="250px" OnClick="Button1_Click" class="btn-primary" />

        </div>

            </form>
            
            </div>
    
        </div>

    </main>
</body>
</html>
