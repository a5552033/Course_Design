using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
/// <summary>
///ClassM 的摘要说明
/// </summary>
public class ClassM
{
  
	public ClassM()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    /// <summary>
    /// 检查班级是否存在
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public bool ExitClass(string code)
    {
        SqlParameter para1 = new SqlParameter("@code", code);
        string sqlStr = "select count(*) from class where class_code=@code";
        int num = int.Parse(DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para1).ToString());
        if (num > 0)
            return true;
        else
            return false;
    }
    /// <summary>
    /// 添加班级
    /// </summary>
    /// <param name="name"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    public bool AddClass(string name, string code)
    {
        if (this.ExitClass(code))
        {
            return false;
        }
        else
        {
            SqlParameter para1 = new SqlParameter("@name", name);
            SqlParameter para2 = new SqlParameter("@code", code);
            string sqlStr = "insert into class (class_name,class_code) values (@name,@code)";
            int num = DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr, para1, para2);
            if (num > 0)
                return true;
            else
                return false;
        }
    }
    /// <summary>
    /// 删除班级
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public bool DeleteClass(int ID)
    {
        SqlParameter para = new SqlParameter("@id", ID);
        string sqlStr = "delete from class where class_id=@id";
        int num = DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr, para);
        if (num > 0)
            return true;
        else
            return false;
    }
    /// <summary>
    /// 修改班级信息
    /// </summary>
    /// <param name="ID"></param>
    /// <param name="name"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    public bool UpdateClass(int ID, string name, string code)
    {
        SqlParameter para1 = new SqlParameter("@id", ID);
        SqlParameter para2 = new SqlParameter("@name", name);
        SqlParameter para3 = new SqlParameter("@code", code);
        string sqlStr = "update class set class_name=@name,class_code=@code where class_id=@id";
        int num = DBManager.Instance().ExecuteNonQuery(CommandType.Text, sqlStr, para2, para3, para1);
        if (num > 0)
            return true;
        else
            return false;
    }

    /// <summary>
    /// 读取class的代码
    /// </summary>
    /// <param name="ID"></param>
    /// <param name="name"></param>
    /// <param name="code"></param>
    public string GetClassData(int ID)
    {
        SqlParameter para = new SqlParameter("@id", ID);
        string sqlStr = "select class_code from class where class_id=@id";
        string dr = DBManager.Instance().ExecuteScalar(CommandType.Text, sqlStr, para).ToString();
        return dr;
    }
    /// <summary>
    /// 绑定班级到dropdownlist
    /// </summary>
    /// <param name="ddl"></param>
    public void rDropDownList(DropDownList ddl)
    {
        DataSet ds = new DataSet();
        string sqlStr = "select * from class";
        ds = DBManager.Instance().ExecuteDataSet(CommandType.Text, sqlStr);
        ddl.DataSource = ds;
        ddl.DataTextField = "class_name";
        ddl.DataValueField = "class_name";
        ddl.DataBind();
        ddl.Items.Insert(0, new ListItem("请预约", "0"));
    }
}
public class DB
{
    #region 公共成员
    public static SqlConnection sqlconnection;//定义公共成员
    public static readonly string cnstr = ConfigurationManager.ConnectionStrings["sqlcon"].ToString();//数据库连接字符串
    #endregion

    public DB()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    #region 打开数据库连接
    /// <summary>
    /// 打开数据库连接 返回SqlConnection
    /// </summary>
    /// <returns></returns>
    public static SqlConnection OpenConnection()
    {
        try
        {
            sqlconnection = new SqlConnection(cnstr);
            sqlconnection.Open();
            return sqlconnection;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    #endregion

    #region 关闭数据库连接并释放资源
    /// <summary>
    /// 关闭数据库连接释放资源
    /// </summary>
    /// <param name="Conn">数据库连接对象</param>
    public static void DisposeConnection(SqlConnection Conn)
    {
        if (Conn != null)
        {
            Conn.Close();
            Conn.Dispose();
        }
    }
    #endregion

    #region 执行Sql查询语句
    ///<summary>
    /// 执行Sql查询语句 执行成功返回受影响的行数，执行失败返回-1；
    /// </summary>
    /// <param name="strSQL">传入的Sql语句</param>
    /// <returns>返回受影响的行数</returns>
    public static int ExecuteSql(string strSQL)
    {
        SqlConnection conn = OpenConnection();
        try
        {
            SqlCommand comm = new SqlCommand(strSQL, conn);
            int val = comm.ExecuteNonQuery();

            DisposeConnection(conn);
            return val;

        }
        catch (Exception e)
        {
            DisposeConnection(conn);
            throw new Exception(e.Message);
        }
    }
    #endregion

    #region 返回指定Sql语句的SqlDataReader，请注意，在使用后请关闭本对象，同时将自动调用closeConnection()来关闭数据库连接
    /// <summary>
    /// 返回指定Sql语句的SqlDataReader，请注意，在使用后请关闭本对象，同时将自动调用closeConnection()来关闭数据库连接 
    /// </summary>
    /// <param name="strSQL">传入的Sql语句</param>
    /// <returns>SqlDataReader对象</returns>
    public static SqlDataReader getDataReader(string strSQL)
    {
        SqlConnection conn = OpenConnection();
        SqlDataReader dr = null;
        try
        {
            SqlCommand comm = new SqlCommand(strSQL, conn);
            dr = comm.ExecuteReader();
            return dr;
        }
        catch (Exception ex)
        {
            if (dr != null && !dr.IsClosed)
                dr.Close();
            DisposeConnection(conn);
            throw new Exception(ex.Message);
        }

    }
    #endregion

    #region 返回指定Sql语句的DataTable
    /// <summary>
    /// 返回指定Sql语句的DataTable
    /// </summary>
    /// <param name="strSQL">传入的Sql语句</param>
    /// <returns>DataTable</returns>
    public static DataTable getDataTable(string strSQL)
    {
        SqlConnection conn = OpenConnection();
        try
        {
            SqlCommand comm = new SqlCommand(strSQL, conn);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable table = new DataTable();
            da.Fill(table);

            DisposeConnection(conn);
            return table;
        }
        catch (Exception ex)
        {
            DisposeConnection(conn);
            throw new Exception(ex.Message);
        }
    }
    #endregion

    #region 返回指定Sql语句的DataSet
    /// <summary> 
    /// 返回指定Sql语句的DataSet 
    /// </summary> 
    /// <param name="strSQL">传入的Sql语句</param> 
    /// <returns>DataSet</returns> 
    public static DataSet getDataSet(string strSQL)
    {
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlConnection conn = OpenConnection();
        try
        {
            SqlCommand comm = new SqlCommand(strSQL, conn);
            comm.CommandType = CommandType.Text;
            da.SelectCommand = comm;
            da.Fill(ds);

            DisposeConnection(conn);
            return ds;
        }
        catch (Exception e)
        {
            DisposeConnection(conn);
            throw new Exception(e.Message);
        }
    }
    #endregion

    #region 查询数据库中是否存在该条数据 存在返回True,不存在返回False
    /// <summary>
    /// 是否存在值
    /// </summary>
    /// <param name="strSQL"></param>
    /// <returns></returns>
    public static bool isExists(string strSQL)
    {
        SqlConnection conn = OpenConnection();
        try
        {
            SqlCommand comm = new SqlCommand(strSQL, conn);
            SqlDataReader dr = comm.ExecuteReader();

            if (dr.HasRows) return true;

            DisposeConnection(conn);
            return false;
        }
        catch (Exception ex)
        {
            DisposeConnection(conn);
            throw new Exception(ex.Message);
        }

    }
    #endregion

    #region 获取记录总数
    /// <summary>
    /// 获取查询记录总数
    /// </summary>
    /// <param name="strSql"></param>
    /// <returns></returns>
    public static int getRowCount(string tableNm)
    {
        SqlConnection cn = OpenConnection();
        int intRowCount = 0;

        string str = "select count(*) from (" + tableNm + ")";
        SqlCommand cmd = new SqlCommand(str, cn);
        intRowCount = (int)cmd.ExecuteScalar();
        DisposeConnection(cn);
        return intRowCount;
    }
    #endregion

    #region 为DropDownList绑定数据
    public static void Bind_Dropdownlist(string sql, DropDownList ddl, string value, string textvalue)
    {
        ddl.DataSource = getDataTable(sql);
        ddl.DataTextField = textvalue;
        ddl.DataValueField = value;
        ddl.DataBind();
    }
    #endregion

    #region 为Repeater绑定数据
    public static void Bind_Repeater(string sql, Repeater rpt, SqlConnection cn)
    {
        SqlDataReader dr = getDataReader(sql);
        rpt.DataSource = dr;
        rpt.DataBind();
        dr.Close();
        dr.Dispose();
    }
    #endregion
}
public class Common
{
    public Common()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    #region SHA1加密函数
    public static string SHA1(string source)
    {
        return FormsAuthentication.HashPasswordForStoringInConfigFile(source, "SHA1");
    }
    #endregion

    #region SQL防蛀函数
    public static string UrnHtml(string strHtml)
    {
        strHtml = strHtml.Replace("'", "＇").Replace(".", "．").Replace("%", "％").Replace("-", "－").Replace("<", " ");
        return strHtml;
    }
    #endregion

    #region 过滤字符串中所有的html标签
    public static string checkStr(string text)
    {
        text = text.Trim();
        if (string.IsNullOrEmpty(text))
            return string.Empty;
        text = Regex.Replace(text, "[\\s]{2,}", " "); //两个或多个空格替换为一个
        text = Regex.Replace(text, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", "\n"); //<br>
        text = Regex.Replace(text, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", " "); //&nbsp;
        text = Regex.Replace(text, "<(.|\\n)*?>", string.Empty); //其它任何标记
        text = text.Replace("'", "''");
        return text;
    }//过滤字符串中所有的标签代码，如<img.../> ,<p></p>等
    #endregion

    #region 字符串截取函数
    public static string subString(string str, int length)
    {
        string tmpStr = str;
        int strLength = length;
        if (str.Length > strLength)
        {
            tmpStr = str.Substring(0, strLength);

        }
        return tmpStr;
    }//截取从字符串开始位置到指定位置的字符
    #endregion

    #region 截取字符串函数

    #region 截取字符串函数
    /// <summary>
    /// 截取字符串函数
    /// </summary>
    /// <param name="str">所要截取的字符串</param>
    /// <param name="num">截取字符串的长度(0则不判断)</param>
    /// <returns></returns>
    public static string GetSubString(object str, int num)
    {
        return GetSubString(str.ToString(), num);
    }
    #endregion

    /// <summary>
    /// 截取字符串函数
    /// </summary>
    /// <param name="str">所要截取的字符串</param>
    /// <param name="num">截取字符串的长度(0则不判断)</param>
    /// <param name="laststr">后缀字符（如：..）</param>
    /// <returns></returns>
    public static string GetSubString(string str, int num, string laststr)
    {
        //if (num > 0)
        //{
        //    return (RemoveHTML(str).Length > num) ? (RemoveHTML(str).Substring(0, num)) : str;
        //}
        //else
        //{
        //    return str;
        //}

        if (Encoding.UTF8.GetByteCount(str) <= num * 2)
        {
            return str;
        }
        ASCIIEncoding ascii = new ASCIIEncoding();
        int tempLen = 0;
        string tempString = "";
        byte[] s = ascii.GetBytes(str);
        for (int i = 0; i < s.Length; i++)
        {
            if ((int)s[i] == 63)//汉字
            {
                tempLen += 2;
            }
            else//非汉字
            {
                tempLen += 1;
            }

            if (tempLen > num * 2)
                break;

            tempString += str.Substring(i, 1);
        }

        return tempString + laststr;
    }
    #endregion

    #region 搜索HTML代码中的<img>标签，并返回<img>标签中的图片地址，如果没有则返回“--”
    public static string GetHtmlImageUrlList(string sHtmlText)
    {
        // 定义正则表达式用来匹配 img 标签
        Regex regImg = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);

        // 搜索匹配的字符串
        MatchCollection matches = regImg.Matches(sHtmlText);

        int i = 0;
        string[] sUrlList = new string[matches.Count];

        // 取得匹配项列表
        foreach (Match match in matches)
            sUrlList[i++] = match.Groups["imgUrl"].Value;
        if (sUrlList.Length <= 0)
        {
            return "--";
        }
        return sUrlList[0];
    } //此函数的功能为：搜索HTML代码中的<img>标签，并返回<img>标签中的图片地址，如果没有则返回“--”
    #endregion

    #region 弹出信息提示
    public static void ShowMessage(Page page, string msg, string key)
    {
        string strScript = "<script language=javascript>alert('" + msg + "');</script>";
        ClientScriptManager cs = page.ClientScript;
        Type type = page.GetType();
        if (!cs.IsStartupScriptRegistered(key))
        {
            cs.RegisterStartupScript(type, key, strScript);
        }

    }
    public static void ShowMessage(Page page, string msg, string key, string Redirect)
    {
        string strScript = "<script language=javascript>alert('" + msg + "');window.location.href='" + Redirect + "';</script>";
        ClientScriptManager cs = page.ClientScript;
        Type type = page.GetType();
        if (!cs.IsStartupScriptRegistered(key))
        {
            cs.RegisterStartupScript(type, key, strScript);
        }

    }
    #endregion

    #region HTML转为string并保存到数据库
    /// <summary>
    /// HTML转为string并保存到数据库
    /// </summary>
    /// <param name="strString"></param>
    /// <returns></returns>
    public static string ConvertHtmlToString(string strString)
    {
        strString = strString.Replace("'", "&acute;");
        strString = strString.Replace("“", "&ldquo;");
        strString = strString.Replace("”", "&rdquo;");
        strString = strString.Replace("\"", "&quot;");
        strString = strString.Replace("<", "&lt;");
        strString = strString.Replace(">", "&gt;");
        strString = strString.Replace("/", "&#8224;");
        return strString;
    }
    #endregion

    #region 从数据库读出信息并转为HTML
    /// <summary>
    /// 从数据库读出信息并转为HTML
    /// </summary>
    /// <param name="strString"></param>
    /// <returns></returns>
    public static string ConvertStringToHtml(string strString)
    {
        strString = strString.Replace("&acute;", "'");
        strString = strString.Replace("&ldquo;", "“");
        strString = strString.Replace("&rdquo;", "”");
        strString = strString.Replace("&quot;", "\"");
        strString = strString.Replace("&lt;", "<");
        strString = strString.Replace("&gt;", ">");
        strString = strString.Replace("&#8224;", "/");
        //strString = strString.Replace(" ", "&nbsp;");
        //strString = strString.Replace("　", "&nbsp;&nbsp;");
        return strString;
    }
    #endregion

    #region 上传图片，若上传成功，返回文件在服务器的虚拟路径，否则返回指定字符串
    /// <summary>
    /// 上传图片，若上传成功，返回文件在服务器的虚拟路径，否则返回指定字符串
    /// </summary>
    /// <param name="fld">filupload 控件</param>
    ///<param name="pg">Page</param>
    ///<param name="ret_str">上传失败时返回的字符串</param>
    public static string UploadFile(FileUpload fld, Page pg, string ret_str)
    {
        string fname1 = "";
        string exName = System.IO.Path.GetExtension(fld.FileName).ToLower();
        if (fld.HasFile)
        {
            if (exName != ".jpg" && exName != ".jepg" && exName != ".gif" && exName != ".bmp")
            {
                Common.ShowMessage(pg, "图片格式不正确！", "kk");
                return ret_str;
            }
            else
            {
                if (fld.PostedFile.ContentLength > 1058820)
                {
                    Common.ShowMessage(pg, "图片文件大小超过200KB限制！", "kkk");
                    return ret_str;
                }
                else
                {
                    try
                    {
                        fname1 = System.DateTime.Now.ToString("yyyyMMddHHmmssffff");
                        fname1 += exName;
                        fld.SaveAs(System.Web.HttpContext.Current.Server.MapPath("~/UpLoadImg/") + fname1);
                        fname1 = ("/UpLoadImg/" + fname1);
                        return fname1;
                    }
                    catch (Exception ex)
                    {

                        System.Web.HttpContext.Current.Response.Write("<script>alert('" + ex + "')</script>");
                        return ret_str;
                    }
                }
            }
        }
        else
        {
            Common.ShowMessage(pg, "请预约图片！", "kk");
            return ret_str;
        }
    }
    #endregion


    #region 上传文件，若上传成功，返回文件在服务器的虚拟路径，否则返回指定字符串
    /// <summary>
    /// 上传文件，若上传成功，返回文件在服务器的虚拟路径，否则返回指定字符串
    /// </summary>
    /// <param name="fld">filupload 控件</param>
    ///<param name="pg">Page</param>
    ///<param name="ret_str">上传失败时返回的字符串</param>
    public static string UploadFile2(FileUpload fld, Page pg, string ret_str)
    {
        string fname1 = "";
        string exName = System.IO.Path.GetExtension(fld.FileName).ToLower();
        if (fld.HasFile)
        {
            try
            {
                fname1 = System.DateTime.Now.ToString("yyyyMMddHHmmssffff");
                fname1 += exName;
                fld.SaveAs(System.Web.HttpContext.Current.Server.MapPath("~/UpLoadImg/") + fname1);
                fname1 = ("/UpLoadImg/" + fname1);
                return fname1;
            }
            catch (Exception ex)
            {

                System.Web.HttpContext.Current.Response.Write("<script>alert('" + ex + "')</script>");
                return ret_str;
            }
        }
        else
        {
            Common.ShowMessage(pg, "请预约文件！", "kk");
            return ret_str;
        }
    }
    #endregion
}
public class EquipmentDBConnection
{
    public SqlConnection GetEquipmentConnStr()
    {


        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ToString());
        return conn;

    }
}

public class Sbgl_Up : EquipmentDBConnection
{
    /// <summary>
    /// 获取指定ID的设备信息
    /// </summary>
    /// <param name="id">设备的编号</param>
    /// <returns>含指定编号的设备信息的IDataReader</returns>
    public DataSet Get_sb_info(int id)
    {
        using (SqlConnection conn = this.GetEquipmentConnStr())
        {
            string sqlstr = "select * from Equipment where EquipmentID=" + id;
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, conn);
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds);
            return ds;
        }
    }
    /// <summary>
    /// 获取指定设备的所有详细信息
    /// </summary>
    /// <param name="id">设备编号</param>
    /// <returns>包含指定设备详细信息的IDataReader</returns>
    public DataSet Get_Sb_detail(int id)
    {
        using (SqlConnection conn = this.GetEquipmentConnStr())
        {
            string sqlstr = "select a.DepartmentID, a.DepartmentName ,b.EquiStyleName ," +
            "c.EquiSortName ,a.EquiModel ,a.Status ,a.UsePerson ,a.Factory ," +
            "a.LeaveFactoryDate ,a.StockDate ,a.UseDate ,a.Remark  from Equipment a,EquiStyle b,EquiSort c " +
            "where a.EquiStyleID=b.EquiStyleID and a.EquiSortID=c.EquiSortID and a.EquipmentID=" + id;
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, conn);
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds);
            return ds;
        }
    }
    /// <summary>
    /// 获取指定维修记录的详细信息
    /// </summary>
    /// <param name="id">维修记录编号</param>
    /// <returns>维修记录详细信息的IDataReader</returns>
    public DataSet Get_Wx_info(int id)
    {
        using (SqlConnection conn = this.GetEquipmentConnStr())
        {
            string sqlstr = "select * from ServiceInfo where EquipmentID=" + id;
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, conn);
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds, "ServiceInfo");
            conn.Close();
            return ds;
        }
    }

    public void up_Sb_info(ArrayList A)
    {
        using (SqlConnection conn = this.GetEquipmentConnStr())
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UpEquipment";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paraEquipmentID = new SqlParameter("@equipmentID", A[0]);
            cmd.Parameters.Add(paraEquipmentID);

            SqlParameter paramStatus = new SqlParameter("@status", A[1]);
            cmd.Parameters.Add(paramStatus);

            SqlParameter paramUsePerson = new SqlParameter("@usePerson", A[2]);
            cmd.Parameters.Add(paramUsePerson);

            SqlParameter paramEquiModel = new SqlParameter("@equiModel", A[3]);
            cmd.Parameters.Add(paramEquiModel);

            SqlParameter paraFactory = new SqlParameter("@factory", A[4]);
            cmd.Parameters.Add(paraFactory);

            SqlParameter paraLeaveFactoryDate = new SqlParameter("@leaveFactoryDate", A[5]);
            cmd.Parameters.Add(paraLeaveFactoryDate);

            SqlParameter paraUseDate = new SqlParameter("@useDate", A[6]);
            cmd.Parameters.Add(paraUseDate);

            SqlParameter paraStockDate = new SqlParameter("@stockDate", A[7]);
            cmd.Parameters.Add(paraStockDate);

            SqlParameter paraPrice = new SqlParameter("@price", A[8]);
            cmd.Parameters.Add(paraPrice);

            SqlParameter paraAssetsID = new SqlParameter("@assetsID", A[9]);
            cmd.Parameters.Add(paraAssetsID);

            SqlParameter paraWritePerson = new SqlParameter("@writePerson", A[10]);
            cmd.Parameters.Add(paraWritePerson);

            SqlParameter paraRemark = new SqlParameter("@remark", A[11]);
            cmd.Parameters.Add(paraRemark);
            conn.Open();
            cmd.ExecuteNonQuery();
            if (conn.State == ConnectionState.Open)
            { conn.Close(); }
        }
    }
    /// <summary>
    /// 指定的设备维修记录
    /// </summary>
    /// <param name="A">ArrayList类型的设备维修信息记录</param>
    public void up_wx_info(ArrayList A)
    {
        using (SqlConnection conn = this.GetEquipmentConnStr())
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UpServiceInfo";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paraEquipmentID = new SqlParameter("@equipmentID", A[0]);
            cmd.Parameters.Add(paraEquipmentID);
            SqlParameter paramServicePerson = new SqlParameter("@servicePerson", A[1]);
            cmd.Parameters.Add(paramServicePerson);
            SqlParameter paramServiceTime = new SqlParameter("@serviceTime", A[2]);
            cmd.Parameters.Add(paramServiceTime);
            SqlParameter paramServiceFare = new SqlParameter("@serviceFare", A[3]);
            cmd.Parameters.Add(paramServiceFare);
            SqlParameter paraFailureReason = new SqlParameter("@failureReason", A[4]);
            cmd.Parameters.Add(paraFailureReason);
            SqlParameter paraBeginDate = new SqlParameter("@beginDate", A[5]);
            cmd.Parameters.Add(paraBeginDate);
            SqlParameter paraFinishDate = new SqlParameter("@finishDate", A[6]);
            cmd.Parameters.Add(paraFinishDate);
            SqlParameter paraRemark = new SqlParameter("@remark", A[7]);
            cmd.Parameters.Add(paraRemark);
            conn.Open();
            cmd.ExecuteNonQuery();
            if (conn.State == ConnectionState.Open)
            { conn.Close(); }
        }
    }

    public void UP_Bf_info(ArrayList A)
    {
        using (SqlConnection conn = this.GetEquipmentConnStr())
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UpEquiUseless";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paraEquipmentID = new SqlParameter("@equipmentID", A[0]);
            cmd.Parameters.Add(paraEquipmentID);
            SqlParameter paraSplitParts = new SqlParameter("@splitParts", A[1]);
            cmd.Parameters.Add(paraSplitParts);
            SqlParameter paraUselessDate = new SqlParameter("@UselessDate", A[2]);
            cmd.Parameters.Add(paraUselessDate);
            SqlParameter paraDepreciation = new SqlParameter("@depreciation", A[3]);
            cmd.Parameters.Add(paraDepreciation);
            SqlParameter paraWritePerson = new SqlParameter("@writePerson", A[4]);
            cmd.Parameters.Add(paraWritePerson);
            SqlParameter paraRemark = new SqlParameter("@remark", A[5]);
            cmd.Parameters.Add(paraRemark);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
    /// <summary>
    /// 个性指定的设备运行信息
    /// </summary>
    /// <param name="A">ArrayList类型的设备运行信息数组</param>
    public void UP_Db_info(ArrayList A)
    {
        using (SqlConnection conn = this.GetEquipmentConnStr())
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UpEquiChange";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter paraNew_DepartmentID = new SqlParameter("@new_departmentID", A[0]);
            cmd.Parameters.Add(paraNew_DepartmentID);
            SqlParameter paraNew_DepartmentName = new SqlParameter("@new_departmentName", A[1]);
            cmd.Parameters.Add(paraNew_DepartmentName);
            SqlParameter paraNew_User = new SqlParameter("@new_User", A[2]);
            cmd.Parameters.Add(paraNew_User);
            SqlParameter paraChangeDate = new SqlParameter("@changeDate", A[5]);
            cmd.Parameters.Add(paraChangeDate);
            SqlParameter paraRemark = new SqlParameter("@remark", A[3]);
            cmd.Parameters.Add(paraRemark);
            SqlParameter paraEquiStyleChangeID = new SqlParameter("@equiStyleChangeID", A[4]);
            cmd.Parameters.Add(paraEquiStyleChangeID);
            SqlParameter paraWritePerson = new SqlParameter("@writePerson", A[6]);
            cmd.Parameters.Add(paraWritePerson);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

    }
    /// <summary>
    /// 获取指定设备在所有部门的维修记录
    /// </summary>
    /// <param name="id">设备编号</param>
    /// <returns>包含维修记录的IDataReader</returns>
    //public DataSet Get_Sbwf_L(int id)
    //{
    //    using (SqlConnection conn = this.GetEquipmentConnStr())
    //    {
    //        string sql = "select a.EquipmentID as id,a.EquiModel as sn," +
    //            "a.UsePerson as syr,b.EquiStyleName as sbzl,c.EquiSortName as sblb," +
    //            "a.Status as sbzt from Equipment a,EquiStyle b,EquiSort c " +
    //            "where a.EquiStyleID=b.EquiStyleID and a.EquiSortID=c.EquiSortID ";
    //        Tree_Control zgjg = new Tree_Control();
    //        sql += " and a.DepartmentID in (" + zgjg.Treeinit(Convert.ToInt32(id.ToString())) + "0) and a.Status<>'报废'";
    //        sql += " Group by a.EquipmentID,a.EquiModel,a.UsePerson,b.EquiStyleName,c.EquiSortName,a.Status";
    //        sql += " order by EquipmentID desc";
    //        conn.Open();
    //        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
    //        DataSet ds = new DataSet();
    //        da.Fill(ds);
    //        return ds;
    //    }
    //}
    public void Delid(string table, int id)
    {
        using (SqlConnection conn = this.GetEquipmentConnStr())
        {
            string SQL = "delete from " + table + " where EquipmentID=" + id;
            conn.Open();
            SqlCommand cmd = new SqlCommand(SQL, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
    /// <summary>
    /// 获取指定运行信息的所有内容
    /// </summary>
    /// <param name="id">设备运行信息的编号</param>
    /// <returns>包含指定运行信息的所有内容的IDataReader</returns>
    public DataSet Get_Db_info(int id)
    {
        using (SqlConnection conn = this.GetEquipmentConnStr())
        {
            string sqlstr = "select * from EquiChange where EquiStyleChangeID=" + id;
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
    public DataSet Get_info(string SQLstr)
    {
        using (SqlConnection conn = this.GetEquipmentConnStr())
        {
            string sqlstr = SQLstr;
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(SQLstr, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}



public class Sbgl_Control : EquipmentDBConnection
{
    /// <summary>
    /// 从指定数据表中删除等于字段“ID”指定值的记录`
    /// </summary>
    /// <param name="table">数据表名称</param>
    /// <param name="id">指定值</param>
    public void Delid(string table, int id)
    {
        using (SqlConnection conn = this.GetEquipmentConnStr())
        {
            string SQL = "delete from " + table + " where ServiceID=" + id;
            conn.Open();
            SqlCommand cmd = new SqlCommand(SQL, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
    /// <summary>
    /// 从指定数据表中删除等于指定字段且等于指定值的记录
    /// </summary>
    /// <param name="table">数据表名称</param>
    /// <param name="tj">待删除字段名称</param>
    /// <param name="id">指定值</param>
    public void Delid(string table, string tj, int id)
    {
        using (SqlConnection conn = this.GetEquipmentConnStr())
        {
            string SQL = "delete from " + table + " where " + tj + "=" + id;
            conn.Open();
            SqlCommand cmd = new SqlCommand(SQL, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
    /// <summary>
    /// 获取设备类别列表
    /// </summary>
    /// <returns>包含所有设备类别信息的SqlDataReader</returns>
    public DataSet LbList()
    {
        using (SqlConnection conn = this.GetEquipmentConnStr())
        {
            string sqlstr = "select b.EquiSortID as id,b.EquiSortName as bmnr,a.EquiStyleName as dwmc,a.EquiStyleID as zlid " +
                "from EquiStyle a,EquiSort b where a.EquiStyleID=b.EquiStyleID";
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
    public DataSet GetEquiStyle()
    {
        using (SqlConnection conn = this.GetEquipmentConnStr())
        {
            string sql = "select EquiStyleID as zlid,EquiStyleName as dwmc from EquiStyle";
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
    /// <summary>
    /// 加入设备列表
    /// </summary>
    /// <param name="id"></param>
    /// <param name="bmnr"></param>
    public void Add_sblb(int id, string bmnr)
    {
        using (SqlConnection conn = this.GetEquipmentConnStr())
        {
            string SQL = "insert into EquiSort(EquiSortName,EquiStyleID) values ('" + bmnr + "'," + id + ")";
            conn.Open();
            SqlCommand cmd = new SqlCommand(SQL, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
    /// <summary>
    /// 修改指定的设备类别
    /// </summary>
    /// <param name="id">设备类别编号</param>
    /// <param name="equiStyleName">设备类别名称</param>
    public void update_sblb(int id, int zlid, string equiSortName)
    {
        using (SqlConnection conn = this.GetEquipmentConnStr())
        {
            string SQL = "update EquiSort set EquiSortName='" + equiSortName + "',EquiStyleID='" + zlid + "' where EquiSortID=" + id;
            conn.Open();
            SqlCommand cmd = new SqlCommand(SQL, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="lbid"></param>
    public void Del_sblb(int lbid)
    {
        using (SqlConnection conn = this.GetEquipmentConnStr())
        {
            string SQL = "delete from EquiSort where EquiSortID=" + lbid;
            conn.Open();
            SqlCommand cmd = new SqlCommand(SQL, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
    /// <summary>
    /// 获取设备种类列表 
    /// </summary>
    /// <returns>包含所有设备种类信息的SqlDataReader</returns>
    public DataSet ZlList()
    {
        using (SqlConnection conn = this.GetEquipmentConnStr())
        {
            string sqlstr = "select EquiStyleID as id,EquiStyleName as bmnr from EquiStyle";
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sqlstr, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
    /// <summary>
    /// 加入设备类别
    /// </summary>
    /// <param name="bmnr"></param>
    public void Add_sbzl(string bmnr)
    {
        using (SqlConnection conn = this.GetEquipmentConnStr())
        {
            string SQL = "insert into EquiStyle(EquiStyleName) values ('" + bmnr + "')";
            conn.Open();
            SqlCommand cmd = new SqlCommand(SQL, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
    public void Del_sbzl(string table, int id)
    {
        using (SqlConnection conn = this.GetEquipmentConnStr())
        {
            string SQL = "delete from " + table + " where EquiStyleID=" + id;
            conn.Open();
            SqlCommand cmd = new SqlCommand(SQL, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }

    /// <summary>
    /// 修改指定的设备种类
    /// </summary>
    /// <param name="id">设备种类ID</param>
    /// <param name="equiSyleID">种类ID</param>
    /// <param name="equiSortName">设备类别名称</param>
    public void update_sbzl(int id, string equiStyleName)
    {
        using (SqlConnection conn = this.GetEquipmentConnStr())
        {
            string SQL = "update EquiStyle set EquiStyleName='" + equiStyleName + "' where EquiStyleID=" + id;
            conn.Open();
            SqlCommand cmd = new SqlCommand(SQL, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

    }
    /// <summary>
    /// 修改报废设备的状态为正常
    /// </summary>
    /// <param name="id">报废设备记录编号</param>
    public void Re_Bf(int id)
    {
        using (SqlConnection conn = this.GetEquipmentConnStr())
        {
            string SQL = "update Equipment set Status='正常' where EquipmentID=" + get_sbbh(id);
            SqlCommand cmd = new SqlCommand(SQL, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
    /// <summary>
    /// 获取指定报废设备的设备编号
    /// </summary>
    /// <param name="id">设备报废信息编号</param>
    /// <returns>设备编号</returns>
    private int get_sbbh(int id)
    {
        using (SqlConnection conn = this.GetEquipmentConnStr())
        {
            conn.Open();
            string sqlstr = "select EquipmentID from EquiUseless where EquiUselessID=" + id;
            SqlCommand cmd = new SqlCommand(sqlstr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            string EquipmentID = string.Empty;
            while (dr.Read())
            { EquipmentID = dr["EquipmentID"].ToString(); }
            dr.Close();
            dr.Dispose();
            conn.Close();
            return Convert.ToInt32(EquipmentID);
        }
    }

}