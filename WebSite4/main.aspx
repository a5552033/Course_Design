<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>学籍管理系统</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <br />
    
    <center>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2"
            DataKeyNames="学号" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="None">
            <Columns>
                <asp:BoundField DataField="学号" HeaderText="学号" ReadOnly="True" SortExpression="学号" />
                <asp:BoundField DataField="姓名" HeaderText="姓名" SortExpression="姓名" />
                <asp:BoundField DataField="性别" HeaderText="性别" SortExpression="性别" />
                <asp:BoundField DataField="学院" HeaderText="学院" SortExpression="学院" />
                <asp:BoundField DataField="班级" HeaderText="班级" SortExpression="班级" />
                <asp:BoundField DataField="联系方式" HeaderText="联系方式" SortExpression="联系方式" />
            </Columns>
            <FooterStyle BackColor="Tan" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:StudConnectionString %>"
            DeleteCommand="DELETE FROM [stud_info] WHERE [学号] = @学号" InsertCommand="INSERT INTO [stud_info] ([学号], [姓名], [性别], [学院], [班级], [联系方式]) VALUES (@学号, @姓名, @性别, @学院, @班级, @联系方式)"
            SelectCommand="SELECT [学号], [姓名], [性别], [学院], [班级], [联系方式] FROM [stud_info]" UpdateCommand="UPDATE [stud_info] SET [姓名] = @姓名, [性别] = @性别, [学院] = @学院, [班级] = @班级, [联系方式] = @联系方式 WHERE [学号] = @学号">
            <DeleteParameters>
                <asp:Parameter Name="学号" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="姓名" Type="String" />
                <asp:Parameter Name="性别" Type="String" />
                <asp:Parameter Name="学院" Type="String" />
                <asp:Parameter Name="班级" Type="String" />
                <asp:Parameter Name="联系方式" Type="String" />
                <asp:Parameter Name="学号" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="学号" Type="String" />
                <asp:Parameter Name="姓名" Type="String" />
                <asp:Parameter Name="性别" Type="String" />
                <asp:Parameter Name="学院" Type="String" />
                <asp:Parameter Name="班级" Type="String" />
                <asp:Parameter Name="联系方式" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
    
    </center>
        <center>
            &nbsp;</center>
        <center>
            &nbsp;
            &nbsp;&nbsp;<asp:Button
                ID="Button1" runat="server" OnClick="Button1_Click1" Text="修改密码" />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="录入成绩" /></center>
        <center>
            &nbsp;</center>
        <center>
            &nbsp;</center>
        <center>
            按学年查询：<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>&nbsp;
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="image/cx_05.png" OnClick="ImageButton1_Click" /></center>
        <center>
            &nbsp;</center>
        <center>
            请输入学号删除学生信息：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox> &nbsp; &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="image/sc.gif" OnClick="ImageButton2_Click" /></center>
        <center>
            &nbsp;</center>
            
           <center>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="退出" />&nbsp;</center> 

            
<br />
    </div>
    </form>
</body>
</html>
