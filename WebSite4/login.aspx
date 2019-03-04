<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>学籍管理系统</title>
</head>
<body style="width:100%;height:100%;background:url(Images/Tulips.jpg);background-repeat:no-repeat;">
    <form id="form1" runat="server">
     <div>
      <center><h3 style="font-size:30px;color:black;font-family:华文行楷">学籍管理系统</h3>
          <p>
              <asp:Label ID="Label1" runat="server" Height="23px" Text="用户名" Width="64px"></asp:Label>
              ：<asp:TextBox ID="TextBox1" runat="server" Height="29px" OnTextChanged="TextBox1_TextChanged" ></asp:TextBox></p>
          <p>
              <asp:Label ID="Label2" runat="server" Height="23px" Text="密码" Width="64px"></asp:Label>
              ：<asp:TextBox ID="TextBox2" runat="server" Height="29px" TextMode="Password" ></asp:TextBox></p>
          <p>
              &nbsp;
              <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl = "Images/login_btn.gif" OnClick="ImageButton1_Click"/>
              <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl = "Images/register.gif" OnClick="ImageButton2_Click" Width="81px"/></p>
      </center>     
     </div>
    </form>
</body>
</html>
