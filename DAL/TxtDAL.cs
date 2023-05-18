using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class TxtDAL
    {
        //管理员
        public static DataSet SelectallDAL()
        {
            string sql = "select*from Txt ";
            return DBHelper.GetDataSet(sql);
        }
        public static int DeleteTXTDAL(Model.Txt t)
        {
            string sql = string.Format("delete from Txt where TxtId='{0}'", t.TxtId);
            return DBHelper.zsg(sql);
        }
        public static int UpdateTxtnameDAL(Model.Txt t)
        {
            string sql = string.Format("update Txt set TxtName='{0}'where TxtId='{1}'", t.TxtName, t.TxtId);
            return DBHelper.zsg(sql);
        }

        //普通用户
        public static DataSet SelectDAL(Model.Txt TxtSelectId)
        {
            string sql = string.Format("select*from Txt where UserId='{0}'", TxtSelectId.UserId);
            return DBHelper.GetDataSet(sql);
        }
        public static DataSet TxtSelectByIdDAL(Model.Txt TxtSelectById)
        {
            string sql = string.Format("select*from Txt where TxtId='{0}'", TxtSelectById.TxtId);
            return DBHelper.GetDataSet(sql);
        }
        public static int TxtUpdate1DAL(Model.Txt TxtUpdate)
        {
            string sql = string.Format("update Txt set TxtName='{0}',TxtTime='{1}'where TxtId='{2}'", TxtUpdate.TxtName, TxtUpdate.TxtTime, TxtUpdate.TxtId);
            return DBHelper.zsg(sql);
        }
        public static int TxtDeleteDAL(Model.Txt TxtDelete)
        {
            string sql = string.Format("delete from Txt where TxtId='{0}'", TxtDelete.TxtId);
            return DBHelper.zsg(sql);
        }
        public static int TxtInsertDAL(Model.Txt TxtInsert)
        {
            string sql = string.Format("insert into Txt values('{0}','{1}','{2}','{3}','{4}')", TxtInsert.TxtName, TxtInsert.TxtTime, TxtInsert.TxtSize, TxtInsert.UserId, TxtInsert.TxtUrl);
            return DBHelper.zsg(sql);
        }
        //查询大小
        public static DataSet TxtSizeDAL(Model.Txt Txt)
        {
            string sql = string.Format("select TxtSize from [dbo].[Txt] where UserId='{0}'", Txt.UserId);
            return DBHelper.GetDataSet(sql);
        }
        public static DataSet rightTxtSizeDAL(Model.Txt Txt)
        {
            string sql = string.Format("select LEFT(TxtSize,2) from [dbo].[Txt] where UserId='{0}'", Txt.UserId);
            return DBHelper.GetDataSet(sql);
        }
        public static DataSet selectnameDAL(Model.Txt name)
        {
            string sql = string.Format("select*from Txt where TxtName='{0}'", name.TxtName);
            return DBHelper.GetDataSet(sql);
        }
        public static DataSet uniqueDAL(Model.Txt name)
        {
            string sql = string.Format("select*from Txt where TxtName='{0}' and UserId='{1}'",name.TxtName,name.UserId);
            return DBHelper.GetDataSet(sql);
        }
    }
}
