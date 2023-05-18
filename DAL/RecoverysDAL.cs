using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class RecoverysDAL
    {
        //管理员
        public static DataSet SelectallDAL()
        {
            string sql = "select*from Recoverys ";
            return DBHelper.GetDataSet(sql);
        }
        public static int DeleteTXTDAL(Model.Recoverys r)
        {
            string sql = string.Format("delete from Recoverys where RecoveryId='{0}'", r.RecoveryId);
            return DBHelper.zsg(sql);
        }
        public static int UpdateTxtnameDAL(Model.Recoverys r)
        {
            string sql = string.Format("update Recoverys set RecoveryName='{0}'where RecoveryId='{1}'", r.RecoveryName, r.RecoveryId);
            return DBHelper.zsg(sql);
        }
        //普通用户
        public static DataSet SelectDAL(Model.Recoverys RecoverySelect)
        {
            string sql = string.Format("select*from Recoverys where UserId={0}",RecoverySelect.UserId);
            return DBHelper.GetDataSet(sql);
        }
        public static DataSet SelectByIdDAL(Model.Recoverys RecoverySelectById)
        {
            string sql = string.Format("select*from Recoverys where RecoveryId='{0}'", RecoverySelectById.RecoveryId);
            return DBHelper.GetDataSet(sql);
        }
        public static int RecInsertDAL(Model.Recoverys RecInsert)
        {
            string sql = string.Format("insert into Recoverys values('{0}','{1}','{2}','{3}','{4}','{5}')", RecInsert.RecoveryName, RecInsert.RecoveryTime, RecInsert.RecoverySize, RecInsert.UserId, RecInsert.DiffTime,RecInsert.RecoveryUrl);
            return DBHelper.zsg(sql);
        }
        public static int RecDeleteDAL(Model.Recoverys RecDaelete)
        {
            string sql = string.Format("delete from Recoverys where RecoveryId='{0}'",RecDaelete.RecoveryId);
            return DBHelper.zsg(sql);
        }
        public static DataSet  RecUpSelectDAL(Model.Recoverys RecUpSelect)
        {
            string sql = string.Format("select RecoveryId from Recoverys where UserId='{0}'",RecUpSelect.UserId);
            return DBHelper.GetDataSet(sql);
        }//查询有几个回收数据

        public static int RecUpdateTimeDAL(Model.Recoverys RecUodateTime)
        {
            string sql = string.Format("update Recoverys set DiffTime=(select 10-DATEDIFF(DAY,(select RecoveryTime from Recoverys where RecoveryId='{0}'),(getdate()))) where RecoveryId='{1}' and UserId={2}", RecUodateTime.RecoveryId, RecUodateTime.RecoveryId,RecUodateTime.UserId);
            return DBHelper.zsg(sql);
        }//回收站保存天数

        public static int RecDeleteTimeDAL()
        {
            string sql = string.Format("delete from Recoverys where DiffTime<=0");
            return DBHelper.zsg(sql);
        }//回收站删除
        public static DataSet selectnameDAL(Model.Recoverys name)
        {
            string sql = string.Format("select*from Recoverys where RecoveryName='{0}'",name.RecoveryName);
            return DBHelper.GetDataSet(sql);
        }
    }
}
