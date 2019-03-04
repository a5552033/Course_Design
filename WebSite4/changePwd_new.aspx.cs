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

public partial class changePwd_new : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {

        SqlConnection myconn = new SqlConnection();
        string mystr;
        mystr = "Data Source = localhost;Initial Catalog = Stud;" +
         "Integrated Security = False;User Id = sa;Password = 123456";

        myconn.ConnectionString = mystr;
        myconn.Open();


        if (tbpwd.Text.Trim() == Session["upwd"].ToString().Trim())
        {
            //string newpwd = tbnewpwd.Text.Trim();
            //string unumber = Session["upwd"].ToString().Trim();
            string myupdate = "update stud_info set 密码 = '" + tbnewpwd.Text.Trim() + "' where stud_info.学号 = '" + Session["uno"].ToString().Trim() + "'";

            SqlCommand mycom = new SqlCommand(myupdate, myconn);
            mycom.ExecuteNonQuery();
            myconn.Dispose();
            Response.Write("<script>alert('密码修改成功')</script>");
            Server.Transfer("main.aspx");
        }
        else
        {
            Response.Write("<script>alert('密码输入错误')</script>");
        }
        myconn.Close();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Server.Transfer("main.aspx");
    }
}
