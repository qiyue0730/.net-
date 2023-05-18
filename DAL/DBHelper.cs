using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    class DBHelper
    {
        public static string connstr = "server=.;database=Webdisk;uid=sa;pwd=123456;";
        //增删改方法
        public static int zsg(string sql)
        {   //1.连接数据库对象conn
            SqlConnection conn = new SqlConnection(connstr);
            //1.1打开数据库连接 open()
            conn.Open();
            //2操作数据库对象cmd
            SqlCommand cmd = new SqlCommand(sql, conn);
            //2.1使用cmd.ENQ()执行增删改 返回受影响的行数rows
            int rows = cmd.ExecuteNonQuery();
            //2.2关闭数据库连接
            conn.Close();
            //3 返回行数
            return rows;//为了返回给 窗体 用rows 去做判断和弹消息框         
        }
        //查询方法
        public static DataSet GetDataSet(string sql)
        {
            //1.连接数据库对象 conn
            SqlConnection conn = new SqlConnection(connstr);
            //2.临时数据库 ds
            DataSet ds = new DataSet();
            //3.搬运工   数据适配器 dap
            SqlDataAdapter dap = new SqlDataAdapter(sql, conn);
            //4.填充数据
            dap.Fill(ds);
            //5.返回ds
            return ds;
        }
    }
}
