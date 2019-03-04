using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;


public partial class register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Alert js = new Alert();
        string mystr,sex;
        sex = "";
        SqlConnection myconn = new SqlConnection();
        SqlCommand mycmd = new SqlCommand();

        mystr = "Data Source = localhost;Initial Catalog = Stud;" +
         "Integrated Security = False;User Id = sa;Password = 123456";

        myconn.ConnectionString = mystr;
        myconn.Open();

        SqlCommand cmd = new SqlCommand("select * from stud_info where 学号 ='" + TextBox1.Text.Trim() + "'", myconn);
        SqlDataReader sdr = cmd.ExecuteReader();

        sdr.Read();
        if (sdr.HasRows)
            Alert.AlertAndRedirect("用户已注册，请登录", "login.aspx");
        else
        {
            if(RadioButton1.Checked == true)
                sex = RadioButton1.Text.Trim();
            if (RadioButton3.Checked == true)
                sex = RadioButton3.Text.Trim();
            
            sdr.Close();
            string myinsert = "insert into stud_info(学号,姓名,密码,班级,学院,联系方式,性别)values('"
                + TextBox1.Text.Trim() + "' ,'" + TextBox6.Text.Trim() + "' ,'" + TextBox2.Text.Trim() + "' ,'" + TextBox7.Text.Trim()
                + "' ,'" + TextBox4.Text.Trim() + "' ,'" + TextBox8.Text.Trim() + "' ,'" + sex + "')";

            SqlCommand mycom = new SqlCommand(myinsert, myconn);
            mycom.ExecuteNonQuery();
            myconn.Dispose();
            Alert.AlertAndRedirect("注册成功", "login.aspx");
        }
        myconn.Close();
    }
}
