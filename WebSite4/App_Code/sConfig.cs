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
/// Config 的摘要说明
/// </summary>
public class sConfig
{
    public sConfig()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    /// <summary>
    /// 修改配置
    /// </summary>
    /// <param name="count"></param>
    /// <returns></returns>
    public bool UpdateConfig(int count)
    {
        SqlParameter para = new SqlParameter("@count", count);
        string sqlStr = "update config set config_count=@count where config_id=1";
        int num = DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr, para);
        if (num > 0)
            return true;
        else
            return false;
    }
    /// <summary>
    /// 获取最大预约数量
    /// </summary>
    /// <returns></returns>
    public int GetConfig()
    {
        string sqlStr = "select config_count from config where config_id=1";
        int count = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr).ToString());
        return count;
    }
}
