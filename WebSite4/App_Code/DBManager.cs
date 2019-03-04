using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
/// <summary>
///DBManager 的摘要说明
/// </summary>
public class DBManager
{
	public DBManager()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//

	}
    //连接字符串
    public static readonly string myConnStr = ConfigurationManager.ConnectionStrings["sqlcon"].ToString();
    //默认　System.Data.SqlClient
    public static readonly string dbProviderName = string.IsNullOrEmpty(ConfigurationManager.AppSettings["dbProviderName"])
                                                ? "System.Data.SqlClient" : ConfigurationManager.AppSettings["dbProviderName"];
    [ThreadStatic]
    static DBHelper helper;
    public static DBHelper Instance()
    {
        if (helper == null)
        {
            helper = new DBHelper(myConnStr, dbProviderName);
            return helper;
        }
        return helper;
    }
}