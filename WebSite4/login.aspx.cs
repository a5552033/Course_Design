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

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Alert js = new Alert();
        string mystr, mysql;
        SqlConnection myconn = new SqlConnection();
        SqlCommand mycmd = new SqlCommand();
   
        mystr = "Data Source = localhost;Initial Catalog = Stud;" +
         "Integrated Security = False;User Id = sa;Password = 123456";

        myconn.ConnectionString = mystr;
        myconn.Open();

        mysql = "SELECT stud_info.密码 FROM stud_info where 学号 = @no";
        mycmd.CommandText = mysql;
        mycmd.Connection = myconn;
        mycmd.Parameters.Add("@no", SqlDbType.VarChar, 10).Value = TextBox1.Text.Trim();
  

        if (TextBox1.Text == "" || TextBox2.Text == "")
        {
            Alert.AlertAndRedirect("没有输入账号和密码！", "login.aspx");
        }
        else
        {
            if (TextBox2.Text.Trim() == mycmd.ExecuteScalar().ToString().Trim())
            {
                Alert.AlertAndRedirect("登陆成功", "main.aspx");

                SqlCommand cmd = new SqlCommand("select * from stud_info where 学号 ='" + TextBox1.Text.Trim() + "'", myconn);
                SqlDataReader sdr = cmd.ExecuteReader();

                sdr.Read();
            
                Session["uname"] = sdr["姓名"].ToString().Trim();
                Session["uno"] = sdr["学号"].ToString().Trim();
                Session["upwd"] = sdr["密码"].ToString().Trim();
                Session["uclass"] = sdr["班级"].ToString().Trim();

                sdr.Close();
                
            }
            else
            {
                Alert.AlertAndRedirect("账号或者密码不对请重新登陆！", "login.aspx");
            }
        }
        myconn.Close();
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Alert js = new Alert();
        Alert.AlertAndRedirect("欢迎注册", "register.aspx");
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
}
