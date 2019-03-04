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
///Course 的摘要说明
/// </summary>
public class Course
{
	public Course()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    /// <summary>
    /// 判断会议室是否已存在
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public bool ExitCourse(string code)
    {
        SqlParameter para1 = new SqlParameter("@code", code);
        string sqlStr = "select count(*) from course where course_code=@code";
        int num = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para1).ToString());
        if (num > 0)
            return true;
        else
            return false;
    }
    /// <summary>
    /// 添加会议室
    /// </summary>
    /// <param name="name"></param>
    /// <param name="code"></param>
    /// <param name="Class"></param>
    /// <returns></returns>
    public bool AddCourse(string name, string code, string time, string classroom,string text)
    {
        if (this.ExitCourse(code))
        {
            return false;
        }
        else
        {
            SqlParameter para1 = new SqlParameter("@name", name);
            SqlParameter para2 = new SqlParameter("@code", code);
          
            SqlParameter para4 = new SqlParameter("@time", time);
            SqlParameter para5 = new SqlParameter("@class", classroom);
           
            SqlParameter para10 = new SqlParameter("@text", text);
            string sqlStr = "insert into course (course_name,course_code,course_time,course_classroom,course_text,course_selected,course_state) values (@name,@code,@time,@class,@text,0,0)";
            int num = DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr, para1, para2, para4, para5, para10);
            if (num > 0)
                return true;
            else
                return false;
        }
    }
    /// <summary>
    /// 删除会议室
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public bool DeleteCourse(int ID)
    {
        SqlParameter para = new SqlParameter("@id", ID);
        string sqlStr = "delete from course where course_id=@id";
        int num = DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr, para);
        if (num > 0)
            return true;
        else
            return false;
    }
    /// <summary>
    /// 修改会议室
    /// </summary>
    /// <param name="ID"></param>
    /// <param name="name"></param>
    /// <param name="code"></param>
    /// <param name="Class"></param>
    /// <returns></returns>
    public bool UpdateCourse(string course_classroom, int ID, string name, string code, string time, string text)
    {
        SqlParameter para0 = new SqlParameter("@course_classroom", course_classroom);
        SqlParameter para1 = new SqlParameter("@id", ID);
        SqlParameter para2 = new SqlParameter("@name", name);
        SqlParameter para3 = new SqlParameter("@code", code);
      
        SqlParameter para5 = new SqlParameter("@time", time);
     
        SqlParameter para11 = new SqlParameter("@text", text);
        string sqlStr = "update course set course_classroom=@course_classroom, course_name=@name,course_code=@code,course_time=@time,course_text=@text where course_id=@id";
        int num = DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr,para0,para2, para3, para5, para11, para1);
        if (num > 0)
            return true;
        else
            return false;
    }
    /// <summary>
    /// 获取会议室代码
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public string GetCourseData(int ID)
    {
        SqlParameter para = new SqlParameter("@id", ID);
        string sqlStr = "select course_code from course where course_id=@id";
        string dr = DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para).ToString();
        return dr;
    }
    /// <summary>
    /// 根据id获取会议室名称
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public string GetCourseName(int ID)
    {
        SqlParameter para = new SqlParameter("@id", ID);
        string sqlStr = "select course_name from course where course_id=@id";
        string name = DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para).ToString();
        return name;
    }
    /// <summary>
    /// 根据id获取会议室需要人数
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public int GetCourseCount(int ID)
    {
      
        int num = 1;
        return num;
    }
    /// <summary>
    /// 根据id获取会议室已预约人数
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public int GetCourseSelected(int ID)
    {
        SqlParameter para = new SqlParameter("@id", ID);
        string sqlStr = "select course_selected from course where course_id=@id";
        int num = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para).ToString());
        return num;
    }
    /// <summary>
    /// 改变指定id的会议室的状态
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public bool UpdateCourseState(int ID)
    {
        SqlParameter para = new SqlParameter("@id", ID);
        string sqlStr = "update course set course_state=1 where course_id=@id";
        int num = DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr, para);
        if (num > 0)
            return true;
        else
            return false;
    }
    /// <summary>
    /// 根据id获取会议室状态
    /// </summary>
    /// <param name="ID"></param>
    /// <returns></returns>
    public int GetCourseState(int ID)
    {
        SqlParameter para = new SqlParameter("@id", ID);
        string sqlStr = "select course_state from course where course_id=@id";
        int state = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para).ToString());
        return state;
    }
}