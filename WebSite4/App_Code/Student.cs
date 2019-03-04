using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
///Student 的摘要说明
/// </summary>
public class Student
{
	public Student()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    /// <summary>
    /// 判断帐号是否存在
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public bool ExitStudent(string code)
    {
        SqlParameter para1 = new SqlParameter("@code", code);
        string sqlStr = "select count(*) from student where student_code=@code";
        int num = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para1).ToString());
        if (num > 0)
            return true;
        else
            return false;
    }
    /// <summary>
    /// 添加用户
    /// </summary>
    /// <param name="name"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    public bool AddStudent(string name, string code)
    {
        if (this.ExitStudent(code))
        {
            return false;
        }
        else
        {
            SqlParameter para1 = new SqlParameter("@name", name);
            SqlParameter para2 = new SqlParameter("@code", code);
      
            string sqlStr = "insert into student (student_name,student_code,student_pwd,student_course) values (@name,@code,'111111',0)";
            int num = DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr, para1, para2);
            if (num > 0)
                return true;
            else
                return false;
        }
    }
    /// <summary>
    /// 删除用户
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public bool DeleteStudent(int ID)
    {
        SqlParameter para = new SqlParameter("@id", ID);
        string sqlStr = "delete from student where student_id=@id";
        int num = DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr, para);
        if (num > 0)
            return true;
        else
            return false;
    }
    /// <summary>
    /// 修改用户信息
    /// </summary>
    /// <param name="ID"></param>
    /// <param name="name"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    public bool UpdateStudent(int ID, string name, string code)
    {
        SqlParameter para1 = new SqlParameter("@id", ID);
        SqlParameter para2 = new SqlParameter("@name", name);
        SqlParameter para3 = new SqlParameter("@code", code);

        string sqlStr = "update student set student_name=@name,student_code=@code where student_id=@id";
        int num = DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr, para2, para3, para1);
        if (num > 0)
            return true;
        else
            return false;
    }
    /// <summary>
    /// 获取用户帐号
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public string GetStudentData(int ID)
    {
        SqlParameter para = new SqlParameter("@id", ID);
        string sqlStr = "select student_code from student where student_id=@id";
        string dr = DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para).ToString();
        return dr;
    }
}