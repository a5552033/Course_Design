<%@ Page Language="C#" AutoEventWireup="true" CodeFile="changePwd_new.aspx.cs" Inherits="changePwd_new" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<<head id="Head1" runat="server">
    <title>密码修改</title>
    <script language="javascript" type="text/javascript" src="../JavaScript/Calendar.js"></script>
    <style type="text/css">
<!--
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
	background-color: #FFFFFF;
}
-->
</style>
    <link href="images/skin.css" rel="stylesheet" type="text/css" />
    <link href="Css/Board.css" type="text/css" rel="Stylesheet" />
    <link href="Css/AdminBack.css" type="text/css" rel="Stylesheet" />
    <link href="Css/tab.css" rel="Stylesheet" type="text/css" />
    <link href="Css/TabList.css" rel="Stylesheet" type="text/css" />
    <link href="Css/AddTab.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    
    <div id="border">   <div id="B_Border">
                                    修改密码 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
</div>
        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="AddTable">
   
            <tr>
                <td valign="top" >
                    <div>
        <table>
    
   
            <tr>
                <td style="width: 100px" align="right">
                    旧 密 码：</td>
                <td style="width: 226px">
                    <asp:TextBox ID="tbpwd" runat="server" CssClass="tb" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvpwd" runat="server" ControlToValidate="tbpwd"
                        Display="Dynamic" ErrorMessage="请输入原来的密码"></asp:RequiredFieldValidator></td>
                <td style="width: 121px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px" align="right">
                    新 密 码：</td>
                <td style="width: 226px">
                    <asp:TextBox ID="tbnewpwd" runat="server" CssClass="tb" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvnew" runat="server" ControlToValidate="tbnewpwd"
                        Display="Dynamic" ErrorMessage="请输入新密码"></asp:RequiredFieldValidator></td>
                <td style="width: 121px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px" align="right">
                    确认密码：</td>
                <td style="width: 226px">
                    <asp:TextBox ID="tbrepwd" runat="server" CssClass="tb" TextMode="Password"></asp:TextBox>
                    <asp:CompareValidator ID="cvpwd" runat="server" ControlToCompare="tbnewpwd" ControlToValidate="tbrepwd"
                        Display="Dynamic" ErrorMessage="两次输入密码不相同"></asp:CompareValidator></td>
                <td style="width: 121px">
                </td>
            </tr>
            </table>
      
    </div>
                </td>
                <td style ="background:url(Images/mail_rightbg.gif)">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center"  style="height: 19px" valign="top">
                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="images/submit.gif" OnClientClick="return clean()"
                        OnClick="ImageButton2_Click" />
                    &nbsp;<asp:Label ID="Label4" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td style ="background:url(Images/mail_rightbg.gif);height: 19px">
                </td>
            </tr>
            <tr>
                <td style ="background:url(Images/buttom_bgs.gif)">
                    
                </td>
                <td valign="bottom" style = "background:url(Images/mail_rightbg.gif)">
                  
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
