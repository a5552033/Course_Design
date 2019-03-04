<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cxcj.aspx.cs" Inherits="cxcj" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>成绩查询</title>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <div style="text-align: center">
        &nbsp;</div>
        <br />
        <br />
        &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
          <br />
                    <center><table style="width: 664px; height: 304px">
        
            <tr>
                <td colspan="3" rowspan="3" style="text-align: center">
                    &nbsp;<br />
                    <asp:Label ID="Label1" runat="server" Width="422px"></asp:Label><br />
                    <br />
                  
                   
                    <br />
                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                        OnSelectedIndexChanged="GridView1_SelectedIndexChanged1">
                        <RowStyle BackColor="#EFF3FB" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                    <br />
                    &nbsp;<br /> 

                    &nbsp;
                    <center></center>
                </td>
            </tr>
            <tr>
            </tr>
            <tr>
            </tr>
        </table></center>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/main.aspx">返回</asp:HyperLink>
        </form>

</body>
</html>
