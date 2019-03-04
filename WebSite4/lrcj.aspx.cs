using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public partial class lrcj : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Alert js = new Alert();
        string mystr;
        SqlConnection myconn = new SqlConnection();
        SqlCommand mycmd = new SqlCommand();

        mystr = "Data Source = localhost;Initial Catalog = Stud;" +
         "Integrated Security = False;User Id = sa;Password = 123456";

        myconn.ConnectionString = mystr;
        myconn.Open();


        string myinsert = "insert into 成绩(学号,学年,课程,平时成绩,考试成绩,总分)values('"
                + TextBox1.Text.Trim() + "' ,'" + TextBox2.Text.Trim() + "' ,'" + TextBox3.Text.Trim() + "' ,'" + TextBox4.Text.Trim()
                + "' ,'" + TextBox5.Text.Trim() + "' ,'" + TextBox6.Text.Trim() + "')";

        SqlCommand mycom = new SqlCommand(myinsert, myconn);
        mycom.ExecuteNonQuery();
        myconn.Dispose();
        Alert.AlertAndRedirect("录入成绩成功", "lrcj.aspx");
        myconn.Close();
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        Server.Transfer("main.aspx");
    }
}
