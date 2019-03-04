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


public partial class main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string mystr;
        //mystr = Session["uname"].ToString() + "同学 ，你好！";
        if (!Page.IsPostBack)
        {
            string mystr;
            SqlConnection myconn = new SqlConnection();
            SqlCommand mycmd = new SqlCommand();

            mystr = "Data Source = localhost;Initial Catalog = Stud;" +
             "Integrated Security = False;User Id = sa;Password = 123456";

            myconn.ConnectionString = mystr;
            myconn.Open();

            DataSet myds1 = new DataSet();
            SqlDataAdapter myda1 = new SqlDataAdapter("SELECT distinct 学年 FROM 成绩", myconn);
            myda1.Fill(myds1, "成绩");
            DropDownList1.DataSource = myds1.Tables["成绩"];
            DropDownList1.DataTextField = "学年";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, "所有学年");
            myconn.Close();
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        Server.Transfer("changePwd_new.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Server.Transfer("login.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Server.Transfer("lrcj.aspx");
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string constr = "";

        if (constr != "")
            if (DropDownList1.SelectedValue != "所有学年")
                constr = constr + "AND 学年 = '" + DropDownList1.SelectedValue + "'";

        if (constr == "")
            if (DropDownList1.SelectedValue != "所有学年")
                constr = "学年 = '" + DropDownList1.SelectedValue + "'";

        Server.Transfer("cxcj.aspx?" + "constr" + constr);
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Alert js = new Alert();
        string mystr, mysql;
        SqlConnection myconn = new SqlConnection();
        SqlCommand mycmd = new SqlCommand();

        mystr = "Data Source = localhost;Initial Catalog = Stud;" +
         "Integrated Security = False;User Id = sa;Password = 123456";

        myconn.ConnectionString = mystr;
        myconn.Open();

        mysql = "DELETE FROM stud_info where 学号 = @no";
        mycmd.CommandText = mysql;
        mycmd.Connection = myconn;
        mycmd.Parameters.Add("@no", SqlDbType.VarChar, 10).Value = TextBox1.Text.Trim();
        mycmd.ExecuteNonQuery();
        Response.Write("<script>alert('删除信息成功')</script>");
        myconn.Close();
    }
}
