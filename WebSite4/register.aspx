<%@ Page Language="C#" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>注册</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <center>
       <h3 style="font-size:30px;color:black;font-family:幼圆">欢迎注册</h3>
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
         
         <td style ="width:128px">
           <asp:RequiredFieldValidator
               ID = "RequiredFieldValidator2" runat = "server" ControlToValidate="TextBox1" ErrorMessage="学号不能为空" Font-Size="10pt" Width="127px"></asp:RequiredFieldValidator>
         </td>
        </tr>
        
          <tr>
          <td style="width:100px;text-align:center">
          <span style="font-size:10pt; color: #0000ff"  >
             <strong> 姓名:</strong>
           </span>
          </td>
          
          
          
          <td style ="width:100px">
           <asp:TextBox ID ="TextBox6" runat="server"
                Font-Size = "10pt"></asp:TextBox>
         </td>
         
         <td style ="width:128px">
           <asp:RequiredFieldValidator
               ID = "RequiredFieldValidator3" runat = "server" ControlToValidate="TextBox6" ErrorMessage="姓名不能为空" Font-Size="10pt" Width="127px"></asp:RequiredFieldValidator>
         </td>
        </tr>
        
        <tr>
          <td style="width:100px;text-align:center">
          <span style="font-size:10pt; color: #0000ff"  >
             <strong> 性别</strong>
           </span>
          </td>
          
          <td style ="width:100px">
            <asp:RadioButton ID = "RadioButton1" runat = "server"
                Font-Bold="True" Font-Size="10pt"
                GroupName = "xy" Text= "男" Checked = "true" />
           
           <asp:RadioButton ID = "RadioButton3" runat = "server"
                Font-Bold="True" Font-Size="10pt"
                GroupName = "xy" Text= "女" /><br/>
           
           <br/>
         </td>
         
        
        </tr>
        <tr>
           <td style="width:100px;text-align:center">
           <span style="font-size:10pt; color: #3300ff"  >
             <strong> 密码:</strong>
           </span>
           </td>
          
          <td style ="width:100px">
           <asp:TextBox ID ="TextBox2" runat="server"
                 TextMode = "Password" Width="159px"></asp:TextBox>
         </td>
         
         <td style ="width:128px">
           <asp:RequiredFieldValidator
               ID = "RequiredFieldValidator1" runat = "server" ControlToValidate="TextBox2" ErrorMessage="密码不能为空" Font-Size="10pt" ></asp:RequiredFieldValidator>
         </td>
        </tr>
        
        <tr>
          <td style="width:100px;text-align:center">
          <span style="font-size:10pt; color: #0000ff"  >
             <strong> 确认密码:</strong>
           </span>
          </td>
          
          <td style ="width:100px">
           <asp:TextBox ID ="TextBox3" runat="server"
                TextMode = "Password" Width="159px"></asp:TextBox>
         </td>
         
         <td style ="width:128px">
           <asp:CompareValidator
               ID = "CompareValidator1" runat = "server" ControlToCompare="TextBox2" ControlToValidate="TextBox3" ErrorMessage="两次密码输入必须相同" Font-Size="10pt" Width="131px"></asp:CompareValidator>
         </td>
        </tr>
        
          <tr>
           <td style="width:100px;text-align:center">
           <span style="font-size:10pt; color: #3300ff"  >
             <strong> 学院:</strong>
           </span>
           </td>
          
          <td style ="width:100px">
           <asp:TextBox ID ="TextBox4" runat="server"></asp:TextBox>
         </td>
         
         <td style ="width:128px">
           <asp:RequiredFieldValidator
               ID = "RequiredFieldValidator4" runat = "server" ControlToValidate="TextBox4" ErrorMessage="学院不能为空" Font-Size="10pt" ></asp:RequiredFieldValidator>
         </td>
        </tr>
        
        <tr>
           <td style="width:100px;text-align:center">
           <span style="font-size:10pt; color: #3300ff"  >
             <strong> 班级:</strong>
           </span>
           </td>
          
          <td style ="width:100px">
           <asp:TextBox ID ="TextBox7" runat="server"></asp:TextBox>
         </td>
         
         <td style ="width:128px">
           <asp:RequiredFieldValidator
               ID = "RequiredFieldValidator5" runat = "server" ControlToValidate="TextBox7" ErrorMessage="班级不能为空" Font-Size="10pt" ></asp:RequiredFieldValidator>
         </td>
        </tr>
        
        
        
          <tr>
          <td style="width:100px;text-align:center">
          <span style="font-size:10pt; color: #0000ff"  >
             <strong>联系电话:</strong>
           </span>
          </td>
          
          <td style ="width:100px">
           <asp:TextBox ID ="TextBox8" runat="server"
                Font-Size = "10pt"></asp:TextBox>
         </td>
         
         <td style ="width:128px">
           <asp:RegularExpressionValidator
               ID = "RegularExpressionValidator2" runat = "server"  ControlToValidate="TextBox8" ErrorMessage="请确保11位电话号码" Font-Size="10pt" Width="127px" ValidationExpression="\S{11}"></asp:RegularExpressionValidator>
         </td>
        </tr>
      </table>
      
      
          
       <br/>
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl = "Images/register(1).gif" OnClick="ImageButton1_Click"/>&nbsp;<br /><br />
        &nbsp;</center>

    </div>
    </form>
</body>
</html>
