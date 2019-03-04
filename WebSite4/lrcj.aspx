<%@ Page Language="C#" AutoEventWireup="true" CodeFile="lrcj.aspx.cs" Inherits="lrcj" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>成绩录入</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <center>
       <h3 style="font-size:30px;color:black;font-family:幼圆">录入学生成绩</h3>
        
        <table>
        <tr>
          <td style="width:100px;text-align:center">
          <span style="font-size:10pt; color: #0000ff"  >
             <strong>学号:</strong>
           </span>
          </td>
          
          <td style ="width:100px">
           <asp:TextBox ID ="TextBox1" runat="server"
                Font-Size = "10pt"></asp:TextBox>
         </td>
         
         
        </tr>
        
          <tr>
          <td style="width:100px;text-align:center">
          <span style="font-size:10pt; color: #0000ff"  >
             <strong> 学年:</strong>
           </span>
          </td>
          
          
          
          <td style ="width:100px">
           <asp:TextBox ID ="TextBox2" runat="server"
                Font-Size = "10pt"></asp:TextBox>
         </td>
         
         
        </tr>
        
        
        <tr>
          <td style="width:100px;text-align:center">
          <span style="font-size:10pt; color: #0000ff"  >
             <strong> 课程:</strong>
           </span>
          </td>
          
          
          
          <td style ="width:100px">
           <asp:TextBox ID ="TextBox3" runat="server"
                Font-Size = "10pt"></asp:TextBox>
         </td>
         
         </tr>
        
          <tr>
           <td style="width:100px;text-align:center">
           <span style="font-size:10pt; color: #3300ff"  >
             <strong> 平日成绩:</strong>
           </span>
           </td>
          
          <td style ="width:100px">
           <asp:TextBox ID ="TextBox4" runat="server"></asp:TextBox>
         </td>
         
        </tr>
        
        <tr>
           <td style="width:100px;text-align:center">
           <span style="font-size:10pt; color: #3300ff"  >
             <strong> 考试成绩:</strong>
           </span>
           </td>
          
          <td style ="width:100px">
           <asp:TextBox ID ="TextBox5" runat="server"></asp:TextBox>
         </td>
         
         
        </tr>
        
        <tr>
           <td style="width:100px;text-align:center">
           <span style="font-size:10pt; color: #3300ff"  >
             <strong> 总分:</strong>
           </span>
           </td>
          
          <td style ="width:100px">
           <asp:TextBox ID ="TextBox6" runat="server"></asp:TextBox>
         </td>
         
         
        </tr>
        
          
      </table>
          <br/>
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl = "Images/submit.gif" OnClick="ImageButton1_Click"/>&nbsp;&nbsp;
        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl = "Images/regist.gif" OnClick="ImageButton2_Click"/>&nbsp;&nbsp;</center>
        <center>
            &nbsp;</center>
        <center>        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl = "Images/first.gif" OnClick="ImageButton3_Click"/>&nbsp;&nbsp;

            <br /><br />

        &nbsp;<br /><br />
        &nbsp;</center>

    </div>
    </form>
</body>
</html>

