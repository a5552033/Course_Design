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
///User 的摘要说明
/// </summary>
public class User
{
	public User()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    /// <summary>
    /// 管理员登陆
    /// </summary>
    /// <param name="name"></param>
    /// <param name="pwd"></param>
    /// <returns></returns>
    public bool AdminLogin(string name, string pwd)
    {
        SqlParameter para1 = new SqlParameter("@name", name);
        SqlParameter para2 = new SqlParameter("@pwd", pwd);
        string sqlStr = "select count(*) from admin where username=@name and pwd=@pwd";
        int num = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para1, para2).ToString());
        if (num > 0)
            return true;
        else
            return false;
    }
    /// <summary>
    /// 用户登录
    /// </summary>
    /// <param name="code"></param>
    /// <param name="pwd"></param>
    /// <returns></returns>
    public bool StudentLogin(string code, string pwd)
    {
        SqlParameter para1 = new SqlParameter("@name", code);
        SqlParameter para2 = new SqlParameter("@pwd", pwd);
        string sqlStr = "select count(*) from student where student_code=@name and student_pwd=@pwd";
        int num = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para1, para2).ToString());
        if (num > 0)
            return true;
        else
            return false;
    }
    /// <summary>
    /// 管理员修改密码
    /// </summary>
    /// <param name="oldpwd"></param>
    /// <param name="newpwd"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public bool AdminPwd(string oldpwd, string newpwd, string name)
    {
        if (this.AdminLogin(name, oldpwd))
        {
            SqlParameter para2 = new SqlParameter("@npwd", newpwd);
            SqlParameter para3 = new SqlParameter("@name", name);
            string sqlStr = "update admin set pwd=@npwd where username=@name";
            int num = DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr, para2, para3);
            if (num > 0)
                return true;
            else
                return false;
        }
        else
            return false;
    }
    /// <summary>
    /// 用户修改密码
    /// </summary>
    /// <param name="oldpwd"></param>
    /// <param name="newpwd"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    public bool StudentPwd(string oldpwd, string newpwd, string code)
    {
        if (this.StudentLogin(code, oldpwd))
        {
            SqlParameter para2 = new SqlParameter("@npwd", newpwd);
            SqlParameter para3 = new SqlParameter("@name", code);
            string sqlStr = "update student set student_pwd=@npwd where student_code=@name";
            int num = DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr, para2, para3);
            if (num > 0)
                return true;
            else
                return false;
        }
        else
            return false;
    }
    /// <summary>
    /// 删除用户的预约
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public bool DeleteSelectCourse(string UserCode, string CourseName)
    {
        string sqlStr1 = "delete from [select] where select_course='" + CourseName + "' and select_student='" + UserCode + "'";
        string sqlStr2 = "update course set course_selected = course_selected - 1 where course_name = '" + CourseName + "'";
        string sqlStr3 = "update student set student_course = student_course - 1 where student_code = '" + UserCode + "'";
        try
        {
            DBManager.Instance().BeginTrans();
            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr1);
            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr2);
            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr3);
            DBManager.Instance().CommitTrans();
            return true;
        }
        catch (Exception)
        {
            DBManager.Instance().RollbackTrans();
            return false;
        }
    }
    /// <summary>
    /// 通过帐号获取姓名
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public string GetUserName(string code)
    {
        SqlParameter para = new SqlParameter("@code", code);
        string sqlStr = "select student_name from student where student_code=@code";
        string name = DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para).ToString();
        return name;
    }
    /// <summary>
    /// 用户预约会议室方法
    /// </summary>
    /// <param name="UserCode">帐号</param>
    /// <param name="CourseName">会议室名称</param>
    /// <returns></returns>
    public bool SelectCourse(string UserCode, string CourseName)
    {

        string sqlStr1 = "insert into [select] (select_course,select_student) values ('" + CourseName + "','" + UserCode + "')";
        //string sqlStr2 = "update course set course_selected = course_selected + 1 where course_name = '" + CourseName + "'";
        string sqlStr3 = "update course set course_sf =1 where course_name = '" + CourseName + "'";
        try
        {
            DBManager.Instance().BeginTrans();
            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr1);
 
            DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr3);
            DBManager.Instance().CommitTrans();
            return true;
        }
        catch (Exception)
        {
            DBManager.Instance().RollbackTrans();
            return false;
        }
    }
    /// <summary>
    /// 通过帐号获取用户已预约数
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public int GetUserSelectCount(string code)
    {
        SqlParameter para = new SqlParameter("@code", code);
        string sqlStr = "select student_course from student where student_code=@code";
        int count = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para).ToString());
        return count;
    }
    /// <summary>
    /// 判断用户是否已预约了这门会议室
    /// </summary>
    /// <param name="CourseName"></param>
    /// <returns></returns>
    public bool ExitCourse(string UserCode, string CourseName)
    {
        SqlParameter para1 = new SqlParameter("@user", UserCode);
        SqlParameter para2 = new SqlParameter("@course", CourseName);
        string sqlStr = "select count(*) from [select] where select_course=@course and select_student=@user";
        int num = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para2, para1).ToString());
        if (num > 0)
            return true;
        else
            return false;
    }

}