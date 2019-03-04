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
///GetDataSet 的摘要说明
/// </summary>
public class GetDataSet
{
	public GetDataSet()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
    /// <summary>
    /// 获取class表记录的条数
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="Code"></param>
    /// <returns></returns>
    public int GetClassSearchCount(TextBox Name, TextBox Code)
    {
        string sb = "select count(*) from class ";
        if (Name.Text != "")
        {
            sb = sb + "where class_name like '%" + Name.Text.Trim() + "%'";
            if (Code.Text != "")
            {
                sb = sb + "and class_code like '%" + Code.Text.Trim() + "%'";
            }
        }
        else
        {
            if (Code.Text != "")
            {
                sb = sb + "where class_code like '%" + Code.Text.Trim() + "%'";
            }
        }
        int num = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sb).ToString().Trim());
        return num;
    }
    /// <summary>
    /// 获取class表的数据集
    /// </summary>
    /// <param name="Name"></param>
    /// <param name="Code"></param>
    /// <param name="pageindex"></param>
    /// <param name="pagesize"></param>
    /// <returns></returns>
    public DataSet GetClassSearchData(TextBox Name, TextBox Code, int pageindex, int pagesize)
    {
        DataSet ds = new DataSet();
        string sb = "select * from class ";
        if (Name.Text != "")
        {
            sb = sb + "where class_name like '%" + Name.Text.Trim() + "%'";
            if (Code.Text != "")
            {
                sb = sb + "and class_code like '%" + Code.Text.Trim() + "%'";
            }
        }
        else
        {
            if (Code.Text != "")
            {
                sb = sb + "where class_code like '%" + Code.Text.Trim() + "%'";
            }
        }
        ds = DBManager.Instance().ExecuteDataSet2(CommandType.Text, sb, pageindex, pagesize, "class");
        return ds;
    }

    /// <summary>
    /// 获取student表的数据条数
    /// </summary>
    /// <param name="ClassCode"></param>
    /// <param name="StudentCode"></param>
    /// <returns></returns>
    public int GetStudentSearchCount()
    {
        string sb = "select count(*) from student ";

        int num = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sb).ToString().Trim());
        return num;
    }
    /// <summary>
    /// 获取student表的数据集
    /// </summary>
    /// <param name="ClassCode"></param>
    /// <param name="StudentCode"></param>
    /// <param name="pageindex"></param>
    /// <param name="pagesize"></param>
    /// <returns></returns>
    public DataSet GetStudentSearchData(int pageindex, int pagesize)
    {
        DataSet ds = new DataSet();
        string sb = "select * from student ";

        ds = DBManager.Instance().ExecuteDataSet2(CommandType.Text, sb, pageindex, pagesize, "student");
        return ds;
    }
    /// <summary>
    /// 获取course表记录条数
    /// </summary>
    /// <param name="State"></param>
    /// <param name="Code"></param>
    /// <returns></returns>
    public int GetCourseSearchCount()
    {
        string sb = "select count(*) from course where 1=1 ";
 
     
        int num = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sb).ToString().Trim());
        return num;
    }
    /// <summary>
    /// 获取course表数据集
    /// </summary>
    /// <param name="State"></param>
    /// <param name="Code"></param>
    /// <param name="pageindex"></param>
    /// <param name="pagesize"></param>
    /// <returns></returns>
    public DataSet GetCourseSearchData(int pageindex, int pagesize, string username)
    {
        DataSet ds = new DataSet();
        string sb = "select * from course,state where course.course_state=state.state_code";
       
        ds = DBManager.Instance().ExecuteDataSet2(CommandType.Text, sb, pageindex, pagesize, "course");
        return ds;
    }
    /// <summary>
    /// 获取用户的预约信息
    /// </summary>
    /// <param name="StudentCode"></param>
    /// <returns></returns>
    public DataSet GetUserCourseData(string StudentCode)
    {
        SqlParameter para = new SqlParameter("@code", StudentCode);
        string sqlStr = "select * from [select],student,course where student.student_code=[select].select_student and student_code=@code and [select].select_course=course.course_name";
        DataSet ds = DBManager.Instance().ExecuteDataSet(CommandType.Text, sqlStr, para);
        return ds;
    }
    public DataSet GetUserCourseData()
    {
        SqlParameter para = new SqlParameter("@code", "");
        string sqlStr = "select * from [select],student,course where student.student_code=[select].select_student and  [select].select_course=course.course_name";
        DataSet ds = DBManager.Instance().ExecuteDataSet(CommandType.Text, sqlStr, para);
        return ds;
    }
    /// <summary>
    /// 获取用户搜索的course表记录条数
    /// </summary>
    /// <param name="State"></param>
    /// <param name="Code"></param>
    /// <returns></returns>
    public int GetUserCourseSearchCount()
    {
        string sb = "select count(*) from course ";
     
        int num = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sb).ToString().Trim());
        return num;
    }
    /// <summary>
    /// 获取用户搜索course表的数据集
    /// </summary>
    /// <param name="State"></param>
    /// <param name="Code"></param>
    /// <param name="pageindex"></param>
    /// <param name="pagesize"></param>
    /// <returns></returns>
    public DataSet GetUserCourseSearchData(int pageindex, int pagesize)
    {
        DataSet ds = new DataSet();
        string sb = "select * from course,state where course.course_state=state.state_code";
      
        ds = DBManager.Instance().ExecuteDataSet2(CommandType.Text, sb, pageindex, pagesize, "course");
        return ds;
    }
}